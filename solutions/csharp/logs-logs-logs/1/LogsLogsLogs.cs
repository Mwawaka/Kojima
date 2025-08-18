public enum LogLevel
{
    Unknown,
    Trace,
    Debug,
    Info = 4,
    Warning,
    Error,
    Fatal = 42,
}

public static class LogLine
{
    public static LogLevel ParseLogLevel(string logLine)
    {

        string levels = logLine.Substring(1, 3);
        switch (levels)
        {
            case "TRC":
                return LogLevel.Trace;
            case "DBG":
                return LogLevel.Debug;
            case "INF":
                return LogLevel.Info;
            case "WRN":
                return LogLevel.Warning;
            case "ERR":
                return LogLevel.Error;
            case "FTL":
                return LogLevel.Fatal;
            default:
                return LogLevel.Unknown;

        }
    }

    public static string OutputForShortLog(LogLevel logLevel, string message) => $"{(int)logLevel}:{message}";  
}