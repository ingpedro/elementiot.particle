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
    public class EventHandler: IEventHandler
    {
        #region Fields
        #endregion

        #region Properties

        /// <summary>
        /// Gets the log service.
        /// </summary>
        /// <value>
        /// The log service.
        /// </value>
        protected ILogPolicy LogService
        { get; }

        /// <summary>
        /// Gets the error service.
        /// </summary>
        /// <value>
        /// The error service.
        /// </value>
        protected IErrorPolicy ErrorService
        { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EventHandler{T}"/> class.
        /// </summary>
        /// <param name="logService">The log service.</param>
        /// <param name="errorService">The error service.</param>
        public EventHandler(ILogPolicy logService, IErrorPolicy errorService)
        {
            this.LogService = logService;
            this.ErrorService = errorService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Handles an error received or thrown in the Api layer and returns an HTTP 500 result with the given error message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="command">The command.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns></returns>
        protected IoTException HandleError(Exception exception, IEvent message, string errorCode = null, string errorMessage = null)
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
