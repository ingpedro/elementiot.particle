using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElementIoT.Particle.Infrastructure.Model.Messaging
{
    /// <summary>
    /// Defines the blueprint for a messaging event.
    /// </summary>
    /// <seealso cref="ElementIoT.Particle.Infrastructure.Model.Messaging.IEvent" />
    public abstract class MessagingEvent: IEvent
    {
        #region Fields
        #endregion

        #region Properties

        [JsonIgnore]
        public Guid Id
        { get; private set; }

        [JsonIgnore]
        public bool IsRetry
        { get; set; }

        [JsonIgnore]
        public Guid SourceId
        { get; set; }

        [JsonIgnore]
        public DateTime? ReceivedDate
        { get; private set; }

        [JsonIgnore]
        public DateTime? HandledDate
        { get; private set; }

        [JsonIgnore]
        public Guid OperationId
        { get; set; }

        #endregion

        #region Constructors

        public MessagingEvent()
        {
            this.ReceivedDate = DateTime.UtcNow;
            this.HandledDate = null;
        }

        #endregion

        #region Methods
        #endregion
    }
}
