using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public void LogError(LogEntry log)
        {
            throw new NotImplementedException();
        }

        public void LogInfo(LogEntry log)
        {
            throw new NotImplementedException();
        }

        public void LogTrace(LogEntry log)
        {
            throw new NotImplementedException();
        }

        public void LogWarning(LogEntry log)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
