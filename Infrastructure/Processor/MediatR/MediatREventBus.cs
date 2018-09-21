using ElementIoT.Particle.Infrastructure.Model.Messaging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElementIoT.Particle.Infrastructure.Processor.MediatR
{
    public class MediatREventBus : IEventBus
    {
        #region Fields
        #endregion

        #region Properties

        protected IMediator MediatorService
        { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MediatREventBus"/> class.
        /// </summary>
        /// <param name="mediatorService">The mediator service.</param>
        public MediatREventBus(IMediator mediatorService)
        {
            this.MediatorService = mediatorService;
        }

        #endregion

        #region Methods
      
        public async Task Publish(INotification @event)
        {
           await this.MediatorService.Publish(@event);
        }

        public async Task Publish(IEnumerable<INotification> events)
        {
            foreach(var @event in events)
            {
                await this.Publish(@event);
            }
        }

        #endregion
    }
}
