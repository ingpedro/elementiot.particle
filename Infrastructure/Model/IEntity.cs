using System;

namespace ElementIoT.Particle.Infrastructure.Model
{
    /// <summary>
    /// Defines the contract for a domain entity
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        Guid Key { get; }
    }
}
