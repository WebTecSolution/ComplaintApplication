using MediatR;
using ComplaintsApplication.Domain.Core.Bus;
using ComplaintsApplication.ReadWrite.Domain.Commands;
using ComplaintsApplication.ReadWrite.Domain.Events;
using System.Threading;
using System.Threading.Tasks;

namespace ComplaintsApplication.ReadWrite.Domain.CommandHandlers
{
    public class UpdateComplaintCommandHandler : IRequestHandler<UpdateComplaintCommand, bool>
    {
        private readonly IEventBus _bus;

        public UpdateComplaintCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }
        public Task<bool> Handle(UpdateComplaintCommand request, CancellationToken cancellationToken)
        {
            //Publish event to RabbitMQ
            _bus.Publish(new UpdateComplaintEvent(request.Id, request.ComplaintDescription, request.ComplaintDate, request.IsResolved, request.ComplaintBy));

            return Task.FromResult(true);
        }
    }
}
