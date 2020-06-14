using ComplaintsApplication.Common.Model;
using System.Collections.Generic;

namespace ComplaintsApplication.Transfer.Domain.Interfaces
{
    public interface IComplaintTransferRepository
    {
        void TransferInsertComplaint(Complaints complaint);
        void TransferUpdateComplaint(int Id, Complaints complaint);
        void TransferDeleteComplaint(int id);
    }
}
