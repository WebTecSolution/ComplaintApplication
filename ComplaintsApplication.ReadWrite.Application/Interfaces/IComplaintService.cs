using ComplaintsApplication.Common.Model;
using System.Collections.Generic;

namespace ComplaintsApplication.ReadWrite.Application.Interfaces
{
    public interface IComplaintService
    {
        IEnumerable<Complaints> GetComplaints();
        Complaints GetComplaintById(int Id);
        void InsertComplaint(Complaints complaint);
        void UpdateComplaint(int Id, Complaints complaint);
        void DeleteComplaint(int Id);
    }
}
