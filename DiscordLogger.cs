namespace DiscordRPforVS
{
    using DiscordRPC.Logging;
    using Microsoft.VisualStudio.Shell;
    using System;

    internal class DiscordLogger : ILogger
    {
        public LogLevel Level { get => LogLevel.Info; set { } }

        public void Error(String message, params Object[] args) => ActivityLog.LogError("DiscordRPC", message);
        public void Info(String message, params Object[] args) => ActivityLog.LogInformation("DiscordRPC", message);
        public void Trace(String message, params Object[] args) => ActivityLog.LogInformation("DiscordRPC TRACE", message);
        public void Warning(String message, params Object[] args) => ActivityLog.LogWarning("DiscordRPC", message);
    }
}
