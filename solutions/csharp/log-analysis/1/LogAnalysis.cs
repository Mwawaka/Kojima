public static class LogAnalysis 
{

    public static string SubstringAfter(this string logLine, string del) =>  logLine.Substring(logLine.IndexOf(del) + del.Length);
    
       public static string SubstringBetween(this string logLine, string del1, string del2){
      int start = logLine.IndexOf(del1) + del1.Length;
      int end = logLine.IndexOf(del2, start);
      return logLine.Substring(start, end - start);
    
    }
       public static string Message(this string logLine)=> SubstringAfter(logLine, ":").Trim();

       public static string LogLevel(this string logLine) => SubstringBetween(logLine, "[", "]");
}