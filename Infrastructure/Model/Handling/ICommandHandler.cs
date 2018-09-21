using ElementIoT.Particle.Infrastructure.Model.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElementIoT.Particle.Infrastructure.Model.Handling
{
    /// <summary>
	/// Marker interface that makes it easier to discover handlers via reflection.
	/// </summary>
	public interface ICommandHandler { }

    public interface ICommandHandler<T> : ICommandHandler
        where T : ICommand
    {
        Task Handle(T command);
    }
}
