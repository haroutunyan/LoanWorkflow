using LoanWorkflow.Api.Abstractions;
using LoanWorkflow.Api.Models.UserAccount;
using LoanWorkflow.Core.Exceptions;
using LoanWorkflow.DAL.Entities.Users;
using LoanWorkflow.Services.Interfaces.Settings;
using LoanWorkflow.Services.Interfaces.Users;
using LoanWorkflow.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.IdentityModel.Tokens.Jwt;

namespace LoanWorkflow.Api.Controllers
{
    public class AccountController(
        ApiContext apiContext,
        IUserService userService,
        IUserTokenService userTokenService,
        ISettings settings,
        IRoleService roleService,
        LoanWorkflowUserManager userManager) : ApiControllerBase(apiContext)
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<ApiResponse<SignInResponseModel>> SignIn(SignInRequestModel model)
        {
            var user = await userService.GetByUserNameAsync(model.UserName);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                await userManager.AddLoginAsync(user);
                await userManager.SetAuthenticationTokenAsync(user);
                var token = await userManager.GenerateAccessTokenAsync(user);
                string refresh = await userManager.GetAuthenticationTokenAsync(
                    user,
                    settings.LoginProviderSettings.LoginProviderName,
                    settings.LoginProviderSettings.TokenName);

                await SaveChangesAsync(user.Id);
                var result = new SignInResponseModel
                {
                    ExpirationDate = token.ValidTo,
                    RefreshToken = refresh,
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                };

                return new ApiResponse<SignInResponseModel>(result);
            }
            throw new InvalidUserNameOrPasswordException();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ApiResponse<RefreshTokenResponseModel>> RefreshToken(RefreshTokenRequestModel model)
        {
            var principal = await userManager.GetPrincipalFromExpiredTokenAsync(model.AccessToken, model.RefreshToken);
            var user = await userService.GetByUserNameAsync(principal.Identity.Name)
                 ?? throw new UnauthorizedException();
            UserToken userToken = await userTokenService.GetByUserIdLoginProviderAndNameAsync(user.Id,
                settings.LoginProviderSettings.LoginProviderName,
                settings.LoginProviderSettings.TokenName);
            if (userToken == null || userToken.ExpirationDate < DateTime.UtcNow || userToken.Value != model.RefreshToken)
                throw new UnauthorizedException();

            await userManager.UpdateRefreshTokenExpirationDate(user);
            await SaveChangesAsync(user.Id);
            JwtSecurityToken newAccessToken = await userManager.GenerateAccessTokenAsync(user);
            var result = new RefreshTokenResponseModel
            {
                ExpirationDate = newAccessToken.ValidTo,
                Token = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                RefreshToken = userToken.Value
            };

            return new ApiResponse<RefreshTokenResponseModel>(result);
        }

        [HttpPost]
        public async Task<IActionResult> SignOut()
        {

            User user = await userManager.FindByIdAsync(UserContext.UserId.ToString());
            await userManager.RemoveAuthenticationTokenAsync(user,
                settings.LoginProviderSettings.LoginProviderName,
                settings.LoginProviderSettings.TokenName);
            return Ok(new ApiResponse());
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserRequestModel model)
        {
            var employee = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PartnerId = model.PartnerId
            };

            var defaultRole = await roleService.GetDefaultRoleAsync();
            var result = await userManager.CreateAsync(employee, model.Password);

            if (result.Succeeded)
            {
                var roleAddResult = await userManager.AddToRoleAsync(employee, defaultRole.NormalizedName);

                if (roleAddResult.Succeeded)
                {
                    return Ok(new ApiResponse<bool>(true));
                }
                
                return BadRequest(new { Errors = roleAddResult.Errors.Select(e => e.Description) });
                
            }
            return BadRequest(new { Errors = result.Errors.Select(e => e.Description) });
        }
    }
}
