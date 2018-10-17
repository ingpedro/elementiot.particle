using ElementIoT.Particle.Operational.Error;
using ElementIoT.Particle.Operational.Logging;
using ElementIoT.Particle.Operational.Resource;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ElementIoT.Particle.Infrastructure.Api
{
    public class CommonController: Controller
    {
        #region Fields
        #endregion

        #region Properties

        /// <summary>
        /// Gets the configuration service.
        /// </summary>
        /// <value>
        /// The configuration service.
        /// </value>
        protected IConfiguration ConfigService
        { get; private set; }

        /// <summary>
        /// Gets the log service.
        /// </summary>
        /// <value>
        /// The log service.
        /// </value>
        protected ILogPolicy LogService
        { get; private set; }


        /// <summary>
        /// Gets the error service.
        /// </summary>
        /// <value>
        /// The error service.
        /// </value>
        protected IErrorPolicy ErrorService
        { get; private set; }

        protected string CurrentUser
        {
            get
            {
                //System.Environment.UserName returns the identity under which the app pool that hosts your web app is running.
                return User?.Identity?.Name ?? Environment.UserName;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CommonController" /> class.
        /// </summary>
        /// <param name="configService">The configuration service.</param>
        /// <param name="logService">The log service.</param>
        /// <param name="errorService">The error service.</param>
        public CommonController(IConfiguration configService, ILogPolicy logService, IErrorPolicy errorService)
        {
            this.ConfigService = configService;
            this.LogService = logService;
            this.ErrorService = errorService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Handles an invalid request by inspecting the Model State and returning an HTTP 400 result
        /// </summary>
        /// <returns></returns>
        protected ObjectResult HandleBadRequest()
        {
            // this.LogService.LogWarning(ErrorMessages.Validation_Invalidinput, new { ModelStateErrors = ModelState.Errors() });
            this.LogService.LogWarning(new LogEntry(CommonErrorMessages.Validation_Invalidinput)
            {

                Arguments = new { ModelStateErrors = ModelState.Errors() }
            });

            ErrorResponse errorResponse = new ErrorResponse("", CommonErrorMessages.Validation_Invalidinput, ModelState.Errors());

            return BadRequest(errorResponse);
        }

        /// <summary>
        /// Handles an error received or thrown in the Api layer and returns an HTTP 500 result with the given error message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns></returns>
        protected ObjectResult HandleError(Exception exception, string errorCode = null, string errorMessage = null)
        {
            var ioTException = this.ErrorService.HandleError(exception, CommonErrorMessages.Error_Unhandled_Exception);

            // this.LogService.LogError(exception, ErrorMessages.Error_Unhandled_Exception);

            var errorResponse = new ErrorResponse(errorCode ?? "Error Code 001", errorMessage ?? exception.Message, ioTException.Errors);

            ObjectResult result = null;
            switch (ioTException.ErrorReasonType)
            {
                case ErrorReasonTypeEnum.Authentication:
                    result = StatusCode((int)HttpStatusCode.Unauthorized, errorResponse);
                    break;
                case ErrorReasonTypeEnum.Unknown:
                    result = StatusCode((int)HttpStatusCode.InternalServerError, errorResponse);
                    break;
                case ErrorReasonTypeEnum.Validation:
                    result = StatusCode((int)HttpStatusCode.BadRequest, errorResponse);
                    break;
            }

            return result;
        }

        #endregion
    }
}
