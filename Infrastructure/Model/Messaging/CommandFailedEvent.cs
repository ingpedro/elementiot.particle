using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElementIoT.Particle.Infrastructure.Model.Messaging
{
    public class CommandFailedEvent : MessagingEvent, INotification
    {
        #region Fields

        #endregion

        #region Properties

        /// <summary>
        /// Gets the failed command.
        /// </summary>
        /// <value>
        /// The failed command.
        /// </value>
        public string FailedCommand
        { get; }

        public Type CommandType
        { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandFailedEvent"/> class.
        /// </summary>
        /// <param name="command">The command.</param>
        public CommandFailedEvent(MessagingCommand command)
        {
            this.IsRetry = false;
            this.FailedCommand = command.ToString();
            this.CommandType = this.GetType();
        }

        #endregion

        #region Methods
        #endregion
    }
}
