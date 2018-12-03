using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElementIoT.Particle.Infrastructure.Model.Messaging
{
    public class CommandReceivedEvent : MessagingEvent, INotification
    {
        #region Fields

        #endregion

        #region Properties

        /// <summary>
        /// Gets the received command.
        /// </summary>
        /// <value>
        /// The failed command.
        /// </value>
        public MessagingCommand Command
        { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandReceivedEvent"/> class.
        /// </summary>
        /// <param name="command">The command.</param>
        public CommandReceivedEvent(MessagingCommand command)
        {
            this.IsRetry = false;
            this.Command = command;
        }

        #endregion

        #region Methods
        #endregion
    }
}
