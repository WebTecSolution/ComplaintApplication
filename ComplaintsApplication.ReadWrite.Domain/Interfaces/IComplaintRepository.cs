using ComplaintsApplication.Common.Model;
using System.Collections.Generic;

namespace ComplaintsApplication.ReadWrite.Domain.Interfaces
{
    public interface IComplaintRepository
    {
        IEnumerable<Complaints> GetComplaints();
        Complaints GetComplaintById(int Id);
    }
}
