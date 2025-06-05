using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Apogee.Core
{
    public enum LogLevel
    {
        Fatal = 0,
        Error = 1,
        Warn = 2,
        Info = 3,
        Debug = 4,
        Trace = 5
    }
    public static class Logger
    {

        private static readonly string[] LevelStrings =
        {
            "[FATAL]: ",
            "[ERROR]: ",
            "[WARN]: ",
            "[INFO]: ",
            "[DEBUG]: ",
            "[TRACE]: "
        };

        public static bool InitializeLogging()
        {
            // TODO: create log file
            return true;
        }

        public static void ShutdownLogging()
        {
            // TODO: cleanup
        }

        public static void LogOutput(LogLevel level, string message, params object[] args)
        {
            string formattedMessage = args.Length > 0 ? string.Format(message, args) : message;

            string outputMessage = $"{LevelStrings[(int)level]}{formattedMessage}\n";

            Console.Write(outputMessage);
        }

        // Fatal-level logging
        public static void AFatal(string message, params object[] args)
        {
            LogOutput(LogLevel.Fatal, message, args);
        }

        // Error-level logging
        public static void AError(string message, params object[] args)
        {
            LogOutput(LogLevel.Error, message, args);
        }

        // Warn-level logging
        [Conditional("LOG_WARN_ENABLED")]
        public static void AWarn(string message, params object[] args)
        {
            LogOutput(LogLevel.Warn, message, args);
        }

        // Info-level logging
        [Conditional("LOG_INFO_ENABLED")]
        public static void AInfo(string message, params object[] args)
        {
            LogOutput(LogLevel.Info, message, args);
        }

        // Debug-level logging
        [Conditional("LOG_DEBUG_ENABLED")]
        public static void ADebug(string message, params object[] args)
        {
            LogOutput(LogLevel.Debug, message, args);
        }

        // Trace-level logging
        [Conditional("LOG_TRACE_ENABLED")]
        public static void ATrace(string message, params object[] args)
        {
            LogOutput(LogLevel.Trace, message, args);
        }

        // Assertion failure reporting
        internal static void ReportAssertionFailure(string expression, string message, string file, int line)
        {
            LogOutput(LogLevel.Fatal, "Assertion failed: {0}\nMessage: {1}\nFile: {2}, Line: {3}", expression, message, file, line);
        }
    }
}
