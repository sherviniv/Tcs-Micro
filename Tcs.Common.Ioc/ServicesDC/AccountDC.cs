using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Tcs.Account.Application.Interfaces;
using Tcs.Account.Application.Services;
using Tcs.Account.Data.Repository;
using Tcs.Account.Domain.Repository;
using Tcs.Common.Infrastructure.MongoDb;
using Tcs.Common.Models.Account.Commands;

namespace Tcs.Common.Ioc.ServicesDC
{
    public class AccountDC
    {

        public static void RegisterServices(IServiceCollection services, IConfiguration Configuration)
        {

            services.AddSingleton(new MongoDbSettings
            {
                ServerConnection = Configuration["ConnectionStrings:MongoDb:ServerConnection"],
                Database = Configuration["ConnectionStrings:MongoDb:DatabaseName"]
            });

            //Repositories
            services.AddScoped<IAccountRepository, AccountRepository>();

            //Services
            services.AddScoped<IAccountService, AccountService>();

            //Domain Commands
            services.AddTransient<IRequestHandler<CreateAccountCommand, bool>, CreateAccountCommandHandler>();

        }

    }
}
