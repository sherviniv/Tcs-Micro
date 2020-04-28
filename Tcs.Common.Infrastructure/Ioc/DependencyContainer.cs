using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Tcs.Common.Domain.Bus;
using Tcs.Common.Infrastructure.Bus;

namespace Tcs.Common.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp => 
            {
                var scopefactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopefactory);
            });
        }
    }
}
