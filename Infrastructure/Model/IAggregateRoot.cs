using System;
using System.Collections.Generic;
using System.Text;

namespace ElementIoT.Particle.Infrastructure.Model
{
    /// <summary>
    /// Defines the contract for a domain agregate
    /// </summary>
    /// <seealso cref="ElementIoT.Particle.Infrastructure.Model.IEntity" />
    public interface IAggregateRoot : IEntity
    {
    }
}
