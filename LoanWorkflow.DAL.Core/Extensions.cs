﻿using LoanWorkflow.DAL.Core.Abstractions;
using LoanWorkflow.DAL.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
                    ma =>
                    {
                        ma.MigrationsAssembly("LoanWorkflow.DAL");
                        ma.CommandTimeout(100);
                    });
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
