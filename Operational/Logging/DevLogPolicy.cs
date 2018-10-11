using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace ElementIoT.Particle.Operational.Logging
{
    /// <summary>
    /// Defines a log policy used for development
    /// </summary>
    /// <seealso cref="ElementIoT.Particle.Operational.Logging.ILogPolicy" />
    public class DevLogPolicy : ILogPolicy
    {
        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Constructors
        #endregion

        #region Methods

        public void LogCritical(LogEntry log)
        {
            Debug.WriteLine(log.ToString());
        }

        public void LogError(LogEntry log)
        {
            Debug.WriteLine(log.ToString());
        }

        public void LogInfo(LogEntry log)
        {
            Debug.WriteLine(log.ToString());
        }

        public void LogTrace(LogEntry log)
        {
            Debug.WriteLine(log.ToString());
        }

        public void LogWarning(LogEntry log)
        {
            Debug.WriteLine(log.ToString());
        }

        #endregion
    }
}
