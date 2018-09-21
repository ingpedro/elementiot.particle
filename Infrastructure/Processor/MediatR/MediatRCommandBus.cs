using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using ElementIoT.Particle.Infrastructure.Model.Messaging;

namespace ElementIoT.Particle.Infrastructure.Processor.MediatR
{
    public class MediatRCommandBus : ICommandBus
    {
        #region Fields
        #endregion

        #region Properties

        protected IMediator MediatorService
        { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MediatRCommandBus"/> class.
        /// </summary>
        /// <param name="mediatorService">The mediator service.</param>
        public MediatRCommandBus(IMediator mediatorService)
        {
            this.MediatorService = mediatorService;
        }

        #endregion

        #region Methods

        public async Task Send(IRequest<string> command)
        {
            await this.MediatorService.Send(command);
        }

        public async Task Send(IEnumerable<IRequest<string>> commands)
        {
            foreach(var command in commands)
            {
                await this.MediatorService.Send(command);
            };
            
        }

        #endregion
    }
}
