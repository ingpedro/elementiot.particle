using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElementIoT.Particle.Operational.Logging
{
    /// <summary>
    /// Defines a log policy that uses the configured Logger for the API
    /// </summary>
    /// <seealso cref="ElementIoT.Particle.Operational.Logging.ILogPolicy" />
    public class ApiLogPolicy : ILogPolicy

    {
        #region Fields
        #endregion

        #region Properties

        protected ILogger<ILogPolicy> LogService
        { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiLogPolicy"/> class.
        /// </summary>
        /// <param name="logService">The log service.</param>
        public ApiLogPolicy(ILogger<ILogPolicy> logService)
        {
            this.LogService = logService;
        }

        #endregion

        #region Methods

        public void LogCritical(LogEntry log)
        {
            Task.Run(() =>
            {
                LogService.LogCritical(this.GetLogDetails(log));
            });
        }

        public void LogError(LogEntry log)
        {
            Task.Run(() =>
            {
                LogService.LogError(this.GetLogDetails(log));
            });
        }

        public void LogInfo(LogEntry log)
        {
            Task.Run(() =>
            {
                LogService.LogInformation(this.GetLogDetails(log));
            });
        }

        public void LogTrace(LogEntry log)
        {
            Task.Run(() =>
            {
                LogService.LogTrace(this.GetLogDetails(log));
            });
        }

        public void LogWarning(LogEntry log)
        {
            Task.Run(() =>
            {
                LogService.LogWarning(this.GetLogDetails(log));
            });
        }

        private string GetLogDetails(LogEntry log)
        {         
            return log.ToString();
        }

        #endregion
    }
}
