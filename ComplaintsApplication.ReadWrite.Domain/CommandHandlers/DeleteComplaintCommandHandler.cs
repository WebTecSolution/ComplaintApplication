using MediatR;
using ComplaintsApplication.Domain.Core.Bus;
using ComplaintsApplication.ReadWrite.Domain.Commands;
using ComplaintsApplication.ReadWrite.Domain.Events;
using System.Threading;
using System.Threading.Tasks;

namespace ComplaintsApplication.ReadWrite.Domain.CommandHandlers
{
    public class DeleteComplaintCommandHandler : IRequestHandler<DeleteComplaintCommand, bool>
    {
        private readonly IEventBus _bus;

        public DeleteComplaintCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }
        public Task<bool> Handle(DeleteComplaintCommand request, CancellationToken cancellationToken)
        {
            //Publish event to RabbitMQ
            _bus.Publish(new DeleteComplaintEvent(request.Id));

            return Task.FromResult(true);
        }
    }
}
