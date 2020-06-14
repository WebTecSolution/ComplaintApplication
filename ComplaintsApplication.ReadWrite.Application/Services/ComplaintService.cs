using ComplaintsApplication.Common.Model;
using ComplaintsApplication.Domain.Core.Bus;
using ComplaintsApplication.ReadWrite.Application.Interfaces;
using ComplaintsApplication.ReadWrite.Domain.Commands;
using ComplaintsApplication.ReadWrite.Domain.Interfaces;
using System.Collections.Generic;

namespace ComplaintsApplication.ReadWrite.Application.Services
{
    public class ComplaintService : IComplaintService
    {
        private readonly IComplaintRepository _complaintRepository;
        private readonly IEventBus _bus;

        public ComplaintService(IComplaintRepository complaintRepository, IEventBus bus)
        {
            _complaintRepository = complaintRepository;
            _bus = bus;
        }
        public IEnumerable<Complaints> GetComplaints()
        {
            return _complaintRepository.GetComplaints();
        }

        public Complaints GetComplaintById(int Id)
        {
            return _complaintRepository.GetComplaintById(Id);
        }

        public void InsertComplaint(Complaints complaint)
        {
            var createNewComplaint = new CreateNewComplaintCommand(complaint.Id,
                                                                     complaint.ComplaintDescription,
                                                                     complaint.ComplaintDate,
                                                                     complaint.IsResolved,
                                                                     complaint.ComplaintBy);
            _bus.SendCommand(createNewComplaint);
        }

        public void UpdateComplaint(int Id, Complaints complaint)
        {
            var updateComplaint = new UpdateComplaintCommand(complaint.Id,
                                                                 complaint.ComplaintDescription,
                                                                 complaint.ComplaintDate,
                                                                 complaint.IsResolved,
                                                                 complaint.ComplaintBy);
            _bus.SendCommand(updateComplaint);
        }

        public void DeleteComplaint(int Id)
        {
            var deleteComplaint = new DeleteComplaintCommand(Id);
            _bus.SendCommand(deleteComplaint);
        }
    }
}
