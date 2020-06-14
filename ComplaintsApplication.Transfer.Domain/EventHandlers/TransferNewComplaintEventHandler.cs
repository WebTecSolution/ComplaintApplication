using ComplaintsApplication.Common.Model;
using ComplaintsApplication.Domain.Core.Bus;
using ComplaintsApplication.Transfer.Domain.Events;
using ComplaintsApplication.Transfer.Domain.Interfaces;
using System.Threading.Tasks;

namespace ComplaintsApplication.Transfer.Domain.EventHandlers
{
    public class TransferNewComplaintEventHandler : IEventHandler<NewComplaintCreatedEvent>
    {
        private readonly IComplaintTransferRepository _complaintTransferRepository;
        public TransferNewComplaintEventHandler(IComplaintTransferRepository complaintTransferRepository)
        {
            _complaintTransferRepository = complaintTransferRepository;
        }
        public Task Handle(NewComplaintCreatedEvent @event)
        {
            _complaintTransferRepository.TransferInsertComplaint(new Complaints()
            {
                Id = @event.Id,
                ComplaintDescription = @event.ComplaintDescription,
                ComplaintDate = @event.ComplaintDate,
                IsResolved = @event.IsResolved,
                ComplaintBy = @event.ComplaintBy
            });
            return Task.CompletedTask;
        }
    }
}
