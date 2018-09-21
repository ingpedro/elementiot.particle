using ElementIoT.Particle.Operational.Resource;
using System;

namespace ElementIoT.Particle.Infrastructure.Model
{
    /// <summary>
    /// Defines the blueprint for a domain entity
    /// </summary>
    /// <seealso cref="ElementIoT.Particle.Infrastructure.Model.IEntity" />
    public abstract class DomainEntity : IEntity
    {
        #region Fields
        #endregion

        #region Prioperties

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Key
        { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainEntity"/> class.
        /// </summary>
        protected DomainEntity()
            : this(Guid.NewGuid())
        { }


        /// <summary>
        /// Initializes a new instance of the <see cref="DomainEntity" /> class.
        /// </summary>
        /// <param name="key">The identifier.</param>
        /// <exception cref="ArgumentException">key</exception>
        protected DomainEntity(Guid key)
        {
            if (object.Equals(key, default(Guid)))
                throw new ArgumentException(CommonErrorMessages.Error_DefaultKey, nameof(key));

            Key = key;
        }

        #endregion

        #region Methods 

        #region Equality Tests

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            var entity = obj as DomainEntity;
            return entity != null &&
                   Key.Equals(entity.Key);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Key);
        }

        #endregion

        #endregion
    }
}
