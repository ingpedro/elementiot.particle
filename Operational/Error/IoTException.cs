using System;
using System.Collections.Generic;

namespace ElementIoT.Particle.Operational.Error
{
    public class IoTException : ApplicationException
    {
        #region Fields
        #endregion

        #region Properties

        public bool IsHandled
        { get; set; }

        public ErrorReasonTypeEnum ErrorReasonType { get; }

        public IEnumerable<string> Errors
        { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="IoTException" /> class.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public IoTException(string message, ErrorReasonTypeEnum errorReasonType = ErrorReasonTypeEnum.Unknown, IEnumerable<string> errors = null)
            : this(message, null)
        {
            this.ErrorReasonType = errorReasonType;
            this.Errors = errors;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IoTException" /> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException" /> parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public IoTException(string message, Exception innerException, ErrorReasonTypeEnum errorReasonType = ErrorReasonTypeEnum.Unknown)
            : base(message, innerException)
        {
            this.IsHandled = false;
            ErrorReasonType = errorReasonType;
        }

        #endregion

        #region Methods
        #endregion
    }
}
