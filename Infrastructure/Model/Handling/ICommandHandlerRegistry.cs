using System;
using System.Collections.Generic;
using System.Text;

namespace ElementIoT.Particle.Infrastructure.Model.Handling
{
    public interface ICommandHandlerRegistry
    {
        void Register(ICommandHandler handler);
    }
}
