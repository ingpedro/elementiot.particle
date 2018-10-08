using ElementIoT.Particle.Operational.Logging;
using ElementIoT.Particle.Operational.Resource;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace ElementIoT.Particle.Operational.Error
{
    /// <summary>
    /// Defines an error handling policy that uses the configured handler for the API
    /// </summary>
    /// <seealso cref="ElementIoT.Particle.Operational.Error.IErrorPolicy" />
    public class ApiErrorPolicy : IErrorPolicy
    {
        #region Fields
        #endregion

        #region Properties

        protected ILogPolicy LogService
        { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiErrorPolicy"/> class.
        /// </summary>
        /// <param name="logService">The log service.</param>
        public ApiErrorPolicy(ILogPolicy logService)
        {
            this.LogService = logService;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Handles the error.
        /// </summary>
        /// <param name="ex">The exception.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns>
        /// A new instance of DigitalAccessException that rep[resents the handled exception.
        /// </returns>
        public IoTException HandleError(Exception ex, string errorMessage = null)
        {
            IoTException handledEx = ex as IoTException;

            // This is a new unhandled exception, we need ot wrap it in our own application exception
            if (handledEx == null)
            {
                handledEx = new IoTException(
                    errorMessage ?? OperationalErrorMessages.Error_Unhandled, ex);
            }

            // If the exception is not handled, then we need to log the exception (handle it) and set the handled flag to true
            // This could be the case when we throw a new DigitalAccessException explicitly from the code,
            // or we received an unhandled exception and we wrapped it here.
            if (!handledEx.IsHandled)
            {
                this.LogService.LogError(
                new LogEntry()
                {
                    Error = handledEx,
                    Message = CommonErrorMessages.Error_Unhandled_Exception
                });

                handledEx.IsHandled = true;
            }

            return handledEx;
        }

        #endregion

        #region Methods
        #endregion
    }
}
