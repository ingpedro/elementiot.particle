using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElementIoT.Particle.Infrastructure.Model.Messaging
{
    /// <summary>
    /// Defines the blueprint for a messaging command
    /// </summary>
    /// <seealso cref="ElementIoT.Particle.Infrastructure.Model.Messaging.ICommand" />
    public abstract class MessagingCommand : ICommand
    {
        #region Fields
        #endregion

        #region Properties

        [JsonIgnore]
        public Guid Id
        { get; private set; }

        [JsonIgnore]
        public DateTime? ReceivedDate
        { get; private set; }

        [JsonIgnore]
        public DateTime? HandledDate
        { get; private set; }

        [JsonIgnore]
        public Guid OperationId
        { get; set; }

        [JsonIgnore]
        public string SenderIdentity
        { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MessagingCommand"/> class.
        /// </summary>
        public MessagingCommand()
        {
            this.ReceivedDate = DateTime.UtcNow;
            this.HandledDate = null;

            this.SenderIdentity = Environment.UserName;
        }

        #endregion

        #region Methods

        public void Handled()
        {
            this.HandledDate = DateTime.UtcNow;
        }

        #endregion
    }
}
