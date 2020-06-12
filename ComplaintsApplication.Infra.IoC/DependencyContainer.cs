using ComplaintsApplication.Domain.Core.Bus;
using ComplaintsApplication.Infra.Bus;
using ComplaintsApplication.Transfer.Domain.Events;
using MediatR;
using ComplaintsApplication.Transfer.Domain.EventHandlers;
using Microsoft.Extensions.DependencyInjection;
using ComplaintsApplication.HRM.Domain.Commands;
using ComplaintsApplication.HRM.Domain.CommandHandlers;
using ComplaintsApplication.HRM.Application.Interfaces;
using ComplaintsApplication.HRM.Application.Services;
using ComplaintsApplication.Transfer.Domain.Interfaces;
using ComplaintsApplication.Transfer.Domain.Repositories;
using ComplaintsApplication.HRM.Domain.Repositories;
using ComplaintsApplication.HRM.Domain.Interfaces;

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

            //Subscriptions
            services.AddTransient<TransferNewEmployeeEventHandler>();
            services.AddTransient<TransferUpdateEmployeeEventHandler>();
            services.AddTransient<TransferDeleteEmployeeEventHandler>();

            //Domain Events
            services.AddTransient<IEventHandler<NewEmployeeCreatedEvent>, TransferNewEmployeeEventHandler>();
            services.AddTransient<IEventHandler<UpdateEmployeeEvent>, TransferUpdateEmployeeEventHandler>();
            services.AddTransient<IEventHandler<DeleteEmployeeEvent>, TransferDeleteEmployeeEventHandler>();

            //Domain Employee Command
            services.AddTransient<IRequestHandler<CreateNewEmployeeCommand, bool>, NewEmployeeCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateEmployeeCommand, bool>, UpdateEmployeeCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteEmployeeCommand, bool>, DeleteEmployeeCommandHandler>();

            // Application Services            
            services.AddTransient<IEmployeeService, EmployeeService>();            
            services.AddTransient<IEmployeeTransferRepository, EmployeeTransferRepository>();            
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();            
        }
    }
}
