using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;
using Tcs.Common.Domain.Bus;
using Tcs.Common.Domain.Models;
using Tcs.Common.Models.Account.Events;
using Tcs.Identity.Application.EventHandlers;
using Tcs.Identity.Application.Handler;
using Tcs.Identity.Application.Interfaces;
using Tcs.Identity.Application.Services;
using Tcs.Identity.Data.Context;
using Tcs.Identity.Data.Repository;
using Tcs.Identity.Domain.Models;
using Tcs.Identity.Domain.Repository;

namespace Tcs.Common.Ioc.ServicesDC
{
    public class IdentityDC
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration Configuration)
        {

            services.AddDbContextPool<TcsIdentityDbContext>(options =>
                     options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, Role>(options =>
            {
                //Password setting
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
            })
                .AddEntityFrameworkStores<TcsIdentityDbContext>()
                   .AddDefaultTokenProviders();

            //Repositories
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();

            //Services
            services.AddScoped<UserManager<ApplicationUser>>();
            services.AddScoped<SignInManager<ApplicationUser>>();

            services.AddScoped<IJwtHandler, JwtHandler>();
            services.AddScoped<IUserService,UserService>();

            //Domain Events
            services.AddTransient<IEventHandler<AccountCreatedEvent>, AccountCreatedEventHandler>();

        }
    }
}
