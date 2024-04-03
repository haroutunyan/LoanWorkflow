using LoanWorkflow.Core.Exceptions;
using LoanWorkflow.DAL.Entities.Users;
using LoanWorkflow.Services.Interfaces.Settings;
using LoanWorkflow.Services.Interfaces.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace LoanWorkflow.Services.Users
{
    public class LoanWorkflowUserManager(
        IUserStore<User> store,
        IOptions<IdentityOptions> optionsAccessor,
        IPasswordHasher<User> passwordHasher,
        IEnumerable<IUserValidator<User>> userValidators,
        IEnumerable<IPasswordValidator<User>> passwordValidators,
        ILookupNormalizer keyNormalizer,
        IdentityErrorDescriber errors,
        IServiceProvider services,
        ILogger<UserManager<User>> logger,
        IUserLoginService userLoginService,
        IUserTokenService userTokenService,
        ISettings settings)
        : UserManager<User>(
            store,
            optionsAccessor,
            passwordHasher,
            userValidators,
            passwordValidators,
            keyNormalizer,
            errors,
            services,
            logger)
    {
        public async Task<IdentityResult> AddLoginAsync(User user)
        {
            var login = new UserLoginInfo(
                settings.LoginProviderSettings.LoginProviderName,
                settings.LoginProviderSettings.LoginProviderKey,
                null);

            var result = await base.AddLoginAsync(user, login);
            if (result.Succeeded)
                await UpdateUserLoginAsync(user.Id, login.LoginProvider, login.ProviderKey);

            return result;
        }

        private async Task UpdateUserLoginAsync(long userId, string loginProvider, string providerKey)
        {
            var userLogin = await userLoginService.GetByProvideerAndKeyAsync(userId, loginProvider, providerKey);
            userLogin.Created = DateTime.UtcNow;
            userLogin.CreatedBy = userId;
            userLogin.ModifiedBy = userId;
            userLoginService.Update(userLogin);
        }

        public async Task<IdentityResult> SetAuthenticationTokenAsync(User user)
        {
            var result = new IdentityResult();
            UserToken userToken = await userTokenService.GetByUserIdLoginProviderAndNameAsync(
                user.Id,
                settings.LoginProviderSettings.LoginProviderName,
                settings.LoginProviderSettings.TokenName);
            DateTime expiration = DateTime.UtcNow.AddDays(settings.JwtSettings.RefreshTokenExpiration);

            if (userToken == null)
            {
                result = await base.SetAuthenticationTokenAsync(
                    user,
                    settings.LoginProviderSettings.LoginProviderName,
                    settings.LoginProviderSettings.TokenName,
                    GenerateRefreshToken());

                userToken = await userTokenService.GetByUserIdLoginProviderAndNameAsync(user.Id,
                    settings.LoginProviderSettings.LoginProviderName,
                    settings.LoginProviderSettings.TokenName);

                if (result.Succeeded)
                    UpdateUserToken(userToken, user.Id, expiration);
            }
            else if (userToken.ExpirationDate.HasValue && userToken.ExpirationDate < DateTime.UtcNow)
            {
                userToken.Value = GenerateRefreshToken();
                userToken.ExpirationDate = expiration;
                userTokenService.Update(userToken);
            }

            return result;
        }

        public async Task UpdateRefreshTokenExpirationDate(User user)
        {
            var userToken = await userTokenService.GetByUserIdLoginProviderAndNameAsync(
                user.Id,
                settings.LoginProviderSettings.LoginProviderName,
                settings.LoginProviderSettings.TokenName);
            DateTime expiration = DateTime.UtcNow.AddDays(settings.JwtSettings.RefreshTokenExpiration);
            userToken.ExpirationDate = expiration;
        }

        public async Task<JwtSecurityToken> GenerateAccessTokenAsync(User user)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.JwtSettings.SecretKey));
            return new JwtSecurityToken(
                issuer: settings.JwtSettings.Issuer,
                audience: settings.JwtSettings.Audience,
                expires: DateTime.UtcNow.AddMinutes(settings.JwtSettings.TokenExpiration),
                claims: await GetClaims(user),
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));
        }

        public async Task<ClaimsPrincipal> GetPrincipalFromExpiredTokenAsync(string accessToken, string refreshToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var principal = tokenHandler.ValidateToken(accessToken, TokenValidationParameters, out SecurityToken securityToken);
                var jwtSecurityToken = securityToken as JwtSecurityToken;
                var userToken = await userTokenService.GetByUserIdAndTokenAsync(long.Parse(principal.Claims.Single(c => c.Type == "userId").Value), refreshToken);
                if (userToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                    throw new InvalidAccessTokenOrRefreshTokenException();
                return principal;
            }
            catch
            {
                throw new InvalidAccessTokenOrRefreshTokenException();
            }
        }

        private void UpdateUserToken(UserToken userToken, long userId, DateTime expiration)
        {
            userToken.Created = DateTime.UtcNow;
            userToken.CreatedBy = userId;
            userToken.ModifiedBy = userId;
            userToken.ExpirationDate = expiration;
            userTokenService.Update(userToken);
        }

        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
  
        private async Task<IList<Claim>> GetClaims(User user)
        {
            IList<Claim> claims =
            [
                 new Claim(ClaimTypes.Name, user.UserName),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                 new Claim(ClaimTypes.Email, user.Email),
                 new Claim("userId", user.Id.ToString()),
                 new Claim(ClaimTypes.Role, "SuperAdmin")
            ];

            IList<string> roleNames = await GetRolesAsync(user);
            foreach (string role in roleNames)
                claims.Add(new Claim(ClaimTypes.Role, role));

            return claims;
        }

        private TokenValidationParameters TokenValidationParameters => new TokenValidationParameters
        {
            ValidateAudience = Convert.ToBoolean(settings.JwtSettings.ValidateAudience),
            ValidateIssuer = Convert.ToBoolean(settings.JwtSettings.ValidateIssuer),
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.JwtSettings.SecretKey)),
        };
    }
}