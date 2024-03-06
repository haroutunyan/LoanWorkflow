using LoanWorkflow.DAL.Core.Abstractions;
using LoanWorkflow.DAL.Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.DAL.Core
{
    public static class Extensions
    {
        public static IServiceCollection ConfigureDal(this IServiceCollection services, Action<DalOptionsBuilder> setupAction)
        {
            var options = new DalOptionsBuilder();
            setupAction?.Invoke(options ?? throw new ArgumentNullException(nameof(setupAction)));

            options.Validate();

            services.AddDbContext<LoanWorkflowContext>(
                contextOptions =>
                {
                    contextOptions.EnableSensitiveDataLogging();
                    contextOptions.EnableDetailedErrors();
                    contextOptions.UseSqlServer(options.ConnectionString,
                    ma => ma.MigrationsAssembly("LoanWorkflow.DAL"));
                }, ServiceLifetime.Scoped);
            services.AddIdentity<User, Role>(identityOptions =>
            {
                
            }).AddEntityFrameworkStores<LoanWorkflowContext>()
            .AddDefaultTokenProviders();

            services.AddScoped(typeof(IDbSetAccessor<>), typeof(DbSetAccessor<>));
            services.AddScoped(typeof(IDbContextAccessor), typeof(DbContextAccessor));
            return services;
        }
    }
}
