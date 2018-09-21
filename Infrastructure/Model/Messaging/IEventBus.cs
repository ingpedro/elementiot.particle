using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElementIoT.Particle.Infrastructure.Model.Messaging
{
    /// <summary>
    /// An event bus that sends serialized object payloads.
    /// </summary>
    public interface IEventBus
    {
        Task Publish(INotification @event);
        Task Publish(IEnumerable<INotification> events);
    }
}
