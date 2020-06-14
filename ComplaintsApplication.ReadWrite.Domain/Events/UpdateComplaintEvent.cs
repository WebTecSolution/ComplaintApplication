using ComplaintsApplication.Domain.Core.Events;
using System;

namespace ComplaintsApplication.ReadWrite.Domain.Events
{
    public class UpdateComplaintEvent : Event
    {
        public int Id { get; private set; }
        public string ComplaintDescription { get; private set; }
        public int? ComplaintBy { get; private set; }
        public DateTime ComplaintDate { get; private set; }
        public bool IsResolved { get; private set; }

        public UpdateComplaintEvent(int id, string complaintDescription, DateTime complaintDate, bool isResolved, int? complaintBy)
        {
            Id = id;
            ComplaintDescription = complaintDescription;
            ComplaintDate = complaintDate;
            IsResolved = isResolved;
            ComplaintBy = complaintBy;
        }
    }
}
