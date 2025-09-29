public static class LogAnalysis 
{
    public static string SubstringAfter(this string logLine,string word) => logLine.Substring(logLine.IndexOf(word) + word.Length);

    public static string SubstringBetween(this string logLine, string word1, string word2) => logLine.Substring(logLine.IndexOf(word1) + word1.Length, logLine.IndexOf(word2) - (logLine.IndexOf(word1) + word1.Length));

      public static string Message(this string logLine) => logLine.Substring(logLine.IndexOf(":") + 1).Trim();
    
      public static string LogLevel(this string logLine) => logLine.SubstringBetween("[","]");
}