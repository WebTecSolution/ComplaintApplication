using ComplaintsApplication.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComplaintsApplication.ReadWrite.Domain.Commands
{
    public class UpdateComplaintCommand : ComplaintCommand
    {
        public UpdateComplaintCommand(int id, string complaintDescription, DateTime complaintDate, bool isResolved, int? complaintBy)
        {
            Id = id;
            ComplaintDescription = complaintDescription;
            ComplaintDate = complaintDate;
            IsResolved = isResolved;
            ComplaintBy = complaintBy;
        }
    }
}
