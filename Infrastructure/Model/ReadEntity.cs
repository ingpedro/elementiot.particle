using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElementIoT.Particle.Infrastructure.Model
{
    /// <summary>
    /// Defins the blueprint for a read entity
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ReadEntity<T>
    {
        #region Fields
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the key for this entity.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonProperty("key")]
        public virtual T Key
        { get; set; }

        /// <summary>
        /// Gets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        [JsonProperty("createdBy", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CreatedBy
        { get; protected set; }

        /// <summary>
        /// Gets the created date.
        /// </summary>
        /// <value>
        /// The created date.
        /// </value>
        [JsonProperty("createdDate", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? CreatedDate
        { get; protected set; }

        /// <summary>
        /// Gets the updated by.
        /// </summary>
        /// <value>
        /// The updated by.
        /// </value>
        [JsonProperty("updatedBy", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string UpdatedBy
        { get; protected set; }

        /// <summary>
        /// Gets the update date.
        /// </summary>
        /// <value>
        /// The update date.
        /// </value>
        [JsonProperty("updateDate", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? UpdateDate
        { get; protected set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        [JsonIgnore]
        public bool IsActive
        { get; protected set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadEntity<T>"/> class.
        /// </summary>
        public ReadEntity()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadEntity{T}"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        public ReadEntity(T key)
        {
            this.Key = key;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadEntity{T}"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public ReadEntity(T key, bool isActive)
        {
            this.Key = key;
            this.IsActive = isActive;
        }

        #endregion

        #region Methods
        #endregion
    }
}
