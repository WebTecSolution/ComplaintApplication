using ComplaintsApplication.Domain.Core.Bus;
using ComplaintsApplication.Transfer.Domain.Events;
using ComplaintsApplication.Transfer.Domain.Interfaces;
using System.Threading.Tasks;

namespace ComplaintsApplication.Transfer.Domain.EventHandlers
{
    public class TransferDeleteComplaintEventHandler : IEventHandler<DeleteComplaintEvent>
    {
        private readonly IComplaintTransferRepository _complaintTransferRepository;
        public TransferDeleteComplaintEventHandler(IComplaintTransferRepository complaintTransferRepository)
        {
            _complaintTransferRepository = complaintTransferRepository;
        }
        public Task Handle(DeleteComplaintEvent @event)
        {
            _complaintTransferRepository.TransferDeleteComplaint(@event.Id);
            return Task.CompletedTask;
        }
    }
}
