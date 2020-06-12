using ComplaintsApplication.Domain.Core.Commands;
using ComplaintsApplication.Domain.Core.Events;
using System.Threading.Tasks;

namespace ComplaintsApplication.Domain.Core.Bus
{
    public interface IEventBus
    {
        Task SendCommand<T>(T command) where T : Command;

        void Publish<T>(T @event) where T : Event;

        void Subscriber<T, TH>()
            where T : Event
            where TH : IEventHandler<T>;
    }
}
