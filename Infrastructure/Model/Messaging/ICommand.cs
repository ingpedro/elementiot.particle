using System;
using System.Collections.Generic;
using System.Text;

namespace ElementIoT.Particle.Infrastructure.Model.Messaging
{
    /// <summary>
    /// Defines the contract for a command
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Gets the command identifier.
        /// </summary>
        Guid Id
        { get; }

        /// <summary>
        /// Gets or sets the received date.
        /// </summary>
        /// <value>
        /// The received date.
        /// </value>
        DateTime? ReceivedDate
        { get; }

        /// <summary>
        /// Gets or sets the handled date.
        /// </summary>
        /// <value>
        /// The handled date.
        /// </value>
        DateTime? HandledDate
        { get; }
    }
}
