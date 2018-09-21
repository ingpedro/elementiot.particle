using System;
using System.Collections.Generic;
using System.Text;

namespace ElementIoT.Particle.Operational.Error
{
    /// <summary>
    /// Defines the contract for an error handling policy
    /// </summary>
    public interface IErrorPolicy
    {
        /// <summary>
        /// Handles the error.
        /// </summary>
        /// <param name="ex">The exception.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns>
        /// A new instance of DigitalAccessException that rep[resents the handled exception.
        /// </returns>
        IoTException HandleError(Exception ex, string errorMessage = null);
    }
}
