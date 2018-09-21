using System;
using System.Collections.Generic;
using System.Text;

namespace ElementIoT.Particle.Infrastructure.Model.Messaging
{
    /// <summary>
    /// Represents an event message.
    /// </summary>
    public interface IEvent
    {
        /// <summary>
        /// Gets the command identifier.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is retry.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is retry; otherwise, <c>false</c>.
        /// </value>
        bool IsRetry { get; }

        /// <summary>
        /// Gets the identifier of the source originating the event.
        /// </summary>
        /// <value>
        /// The source identifier.
        /// </value>
        Guid SourceId { get; }
    }
}
