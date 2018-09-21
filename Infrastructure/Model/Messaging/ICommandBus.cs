using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElementIoT.Particle.Infrastructure.Model.Messaging
{
    public interface ICommandBus
    {
        Task Send(IRequest<string> command);
        Task Send(IEnumerable<IRequest<string>> commands);
    }
}
