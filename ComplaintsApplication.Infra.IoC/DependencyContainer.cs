using ComplaintsApplication.Domain.Core.Bus;
using ComplaintsApplication.Infra.Bus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ComplaintsApplication.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopFactory);
            });
        }
    }
}
