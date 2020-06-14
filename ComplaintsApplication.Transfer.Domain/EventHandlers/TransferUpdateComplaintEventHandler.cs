using ComplaintsApplication.Common.Model;
using ComplaintsApplication.Domain.Core.Bus;
using ComplaintsApplication.Transfer.Domain.Events;
using ComplaintsApplication.Transfer.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComplaintsApplication.Transfer.Domain.EventHandlers
{
    public class TransferUpdateComplaintEventHandler : IEventHandler<UpdateComplaintEvent>
    {
        private readonly IComplaintTransferRepository _complaintTransferRepository;
        public TransferUpdateComplaintEventHandler(IComplaintTransferRepository complaintTransferRepository)
        {
            _complaintTransferRepository = complaintTransferRepository;
        }
        public Task Handle(UpdateComplaintEvent @event)
        {
            _complaintTransferRepository.TransferUpdateComplaint(@event.Id, new Complaints()
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
