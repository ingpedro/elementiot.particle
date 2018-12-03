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
        public abstract string Domain
        { get; set; }

        [JsonIgnore]
        public DateTime? ReceivedDate
        { get; private set; }

        [JsonIgnore]
        public DateTime? HandleStart
        { get; private set; }

        [JsonIgnore]
        public DateTime? HandleEnd
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
        /// Initializes a new instance of the <see cref="MessagingCommand" /> class.
        /// </summary>
        public MessagingCommand()
        {
            this.Id = Guid.NewGuid();
            this.ReceivedDate = DateTime.UtcNow;
            this.HandleStart = null;
            this.HandleEnd = null;

            this.SenderIdentity = Environment.UserName;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Indicates the start of the handling of the command.
        /// </summary>
        public void Handle()
        {
            this.HandleStart = DateTime.UtcNow;
        }

        /// <summary>
        /// Indicates the end of the handling of the command.
        /// </summary>
        public void Handled()
        {
            this.HandleEnd = DateTime.UtcNow;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {            
            return JsonConvert.SerializeObject(this, Formatting.None);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            var command = obj as MessagingCommand;
            return command != null &&
                   Id.Equals(command.Id);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        #endregion
    }
}
