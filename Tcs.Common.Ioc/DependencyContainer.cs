using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tcs.Common.Domain.Bus;
using Tcs.Common.Domain.Models;
using Tcs.Common.Infrastructure.Bus;

namespace Tcs.Common.IoC
{
    public class DependencyContainer
    {
        public static void RegisterBaseServices(IServiceCollection services, IConfiguration Configuration)
        {
            
            services.Configure<MicroSettings>(Configuration.GetSection("MicroSetting"));

            //Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp => 
            {
                var scopefactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopefactory);
            });

        }
    }
}
