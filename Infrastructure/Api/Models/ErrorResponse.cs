using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ElementIoT.Particle.Infrastructure.Api
{
    /// <summary>
    /// Error response
    /// </summary>
    public class ErrorResponse
    {
        #region Fields
        #endregion

        #region Properties

        /// <summary>
        /// Gets the error code.
        /// </summary>
        /// <value>
        /// The error code.
        /// </value>
        public string ErrorCode { get; }

        /// <summary>
        /// Gets the Error Message
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; }

        /// <summary>
        /// Gets the Error Details
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        public IEnumerable Errors { get; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorResponse" /> class.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorMessage">Error Message</param>
        /// <param name="errors">Error Details</param>
        public ErrorResponse(string errorCode, string errorMessage, IEnumerable errors = null)
        {
            this.ErrorCode = errorCode;
            this.ErrorMessage = errorMessage;
            this.Errors = errors;
        }

    }
}
