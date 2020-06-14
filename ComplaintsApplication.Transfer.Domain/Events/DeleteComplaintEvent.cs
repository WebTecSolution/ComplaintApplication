using ComplaintsApplication.Domain.Core.Events;

namespace ComplaintsApplication.Transfer.Domain.Events
{
    public class DeleteComplaintEvent : Event
    {
        public int Id { get; private set; }

        public DeleteComplaintEvent(int id)
        {
            Id = id;
        }
    }
}
