using ElementIoT.Particle.Infrastructure.Model.Messaging;
using ElementIoT.Particle.Operational.Error;
using ElementIoT.Particle.Operational.Logging;
using ElementIoT.Particle.Operational.Resource;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElementIoT.Particle.Infrastructure.Model.Handling
{
    public class CommandHandler<T> : ICommandHandler<T> where T : ICommand
    {
        #region Fields
        #endregion

        #region Properties

        protected IEventBus EventBus
        { get; }

        protected ILogPolicy LogService
        { get; }

        protected IErrorPolicy ErrorService
        { get; }

        #endregion

        #region Constructors

        public CommandHandler(ILogPolicy logService, IErrorPolicy errorService, IEventBus eventBus)
        {
            this.LogService = logService;
            this.ErrorService = errorService;

            this.EventBus = eventBus;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Handles the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        public virtual async Task Handle(T command)
        {
            return;
        }

        /// <summary>
        /// Handles an error received or thrown in the Api layer and returns an HTTP 500 result with the given error message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="command">The command.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns></returns>
        protected IoTException HandleError(Exception exception, ICommand message, string errorCode = null, string errorMessage = null)
        {
            var ioTException = this.ErrorService.HandleError(exception, CommonErrorMessages.Error_Unhandled_Exception);

            this.LogService.LogError(
                new LogEntry()
                {
                    Error = ioTException,
                    Message = CommonErrorMessages.Error_Unhandled_Exception,
                    Arguments = message
                });

            return ioTException;
        }

        #endregion

    }
}
