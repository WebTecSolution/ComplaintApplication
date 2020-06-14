using ComplaintsApplication.Domain.Core.Bus;
using ComplaintsApplication.Infra.Bus;
using ComplaintsApplication.ReadWrite.Application.Interfaces;
using ComplaintsApplication.ReadWrite.Application.Services;
using ComplaintsApplication.ReadWrite.Domain.CommandHandlers;
using ComplaintsApplication.ReadWrite.Domain.Commands;
using ComplaintsApplication.ReadWrite.Domain.Events;
using ComplaintsApplication.ReadWrite.Domain.Interfaces;
using ComplaintsApplication.ReadWrite.Domain.Repositories;
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


            ////Domain Events
            //services.AddTransient<IEventHandler<NewComplaintCreatedEvent>, TransferNewComplaintEventHandler>();
            //services.AddTransient<IEventHandler<UpdateComplaintEvent>, TransferUpdateComplaintEventHandler>();
            //services.AddTransient<IEventHandler<DeleteComplaintEvent>, TransferDeleteComplaintEventHandler>();

            //Domain Complaint Command
            services.AddTransient<IRequestHandler<CreateNewComplaintCommand, bool>, NewComplaintCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateComplaintCommand, bool>, UpdateComplaintCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteComplaintCommand, bool>, DeleteComplaintCommandHandler>();

            // Application Services            
            services.AddTransient<IComplaintService, ComplaintService>();
            services.AddTransient<IComplaintRepository, ComplaintRepository>();
            //services.AddTransient<IComplaintTransferRepository, ComplaintTransferRepository>();
        }
    }
}
