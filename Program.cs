public enum LogLevel
{
    Info,
    Trace,
    Debug,
    Warning,
    Error,
    Fatal
}

public static class LogLine
{
    public static LogLevel ParseLogLevel(string logLine)
    {
        int inx = logLine.IndexOf(':');
        Console.WriteLine("Index:",inx);
        return LogLevel.Info;
    }

    public static string OutputForShortLog(LogLevel logLevel, string message)
    {
        return "hello";
    }
}

public class Program
{

    public static void Main(string[] args)
    {
        LogLine.ParseLogLevel("[INF]: File deleted");
    }
}

