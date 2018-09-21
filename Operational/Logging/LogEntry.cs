using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElementIoT.Particle.Operational.Logging
{
    /// <summary>
    /// Defines an entry for a log message.
    /// </summary>
    public class LogEntry
    {
        #region Fields

        private JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        #endregion

        #region Properties

        public DateTime LogDate
        { get; private set; }

        public string CorrelationId
        { get; private set; }

        public string Message
        { get; set; }

        public string Details
        { get; set; }

        public Exception Error
        { get; set; }

        public dynamic Arguments
        { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LogEntry"/> class.
        /// </summary>
        public LogEntry()
        {
            this.LogDate = DateTime.UtcNow;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogEntry" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="details">The details.</param>
        /// <param name="error">The error.</param>
        public LogEntry(string message)
            :this()
        {
            this.Message = message;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets the correlation identifier.
        /// </summary>
        /// <param name="correlationId">The correlation identifier.</param>
        public void SetCorrelationId(string correlationId)
        {
            this.CorrelationId = string.IsNullOrWhiteSpace(correlationId) 
                ? correlationId 
                : Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {           
            return JsonConvert.SerializeObject(this, jsonSerializerSettings);
        }

        #endregion
    }
}
