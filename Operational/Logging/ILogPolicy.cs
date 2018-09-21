using System;
using System.Threading.Tasks;

namespace ElementIoT.Particle.Operational.Logging
{
    /// <summary>
    /// Defines the contract for a logging policy
    /// </summary>
    public interface ILogPolicy
    {
        /// <summary>
        /// Logs a critical entry
        /// </summary>
        /// <param name="log">The log.</param>
        void LogCritical(LogEntry log);

        /// <summary>
        /// Logs an error entry.
        /// </summary>
        /// <param name="log">The log.</param>
        void LogError(LogEntry log);

        /// <summary>
        /// Logs a warning entry.
        /// </summary>
        /// <param name="log">The log.</param>
        void LogWarning(LogEntry log);

        /// <summary>
        /// Logs an information entry.
        /// </summary>
        /// <param name="log">The log.</param>
        void LogInfo(LogEntry log);

        /// <summary>
        /// Logs a tracing entry.
        /// </summary>
        /// <param name="log">The log.</param>
        void LogTrace(LogEntry log);
    }
}
