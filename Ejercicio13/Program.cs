
    public enum LogLevel
    {
        Unknown = 0,
        Trace = 1,
        Debug = 2,
        Info = 4,
        Warning = 5,
        Error = 6,
        Fatal = 42
    }

    public static class LogLine
    {
        public static LogLevel ParseLogLevel(string logLine)
        {
            int inicio = logLine.IndexOf('[') + 1;
            int fin = logLine.IndexOf(']');
            string abreviatura = logLine.Substring(inicio, fin - inicio);

            return abreviatura switch
            {
                "TRC" => LogLevel.Trace,
                "DBG" => LogLevel.Debug,
                "INF" => LogLevel.Info,
                "WRN" => LogLevel.Warning,
                "ERR" => LogLevel.Error,
                "FTL" => LogLevel.Fatal,
                _ => LogLevel.Unknown
            };
        }

        public static string OutputForShortLog(LogLevel logLevel, string message)
        {
            return $"{(int)logLevel}:{message}";
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Tarea 1: Parse log level conocido
            Console.WriteLine(LogLine.ParseLogLevel("[INF]: File deleted"));
            // Esperado: Info

            Console.WriteLine(LogLine.ParseLogLevel("[ERR]: Stack overflow"));
            // Esperado: Error

            // Tarea 2: Log level desconocido
            Console.WriteLine(LogLine.ParseLogLevel("[XYZ]: Overly specific, out of context message"));
            // Esperado: Unknown

            // Tarea 3: Formato corto
            Console.WriteLine(LogLine.OutputForShortLog(LogLevel.Error, "Stack overflow"));
            // Esperado: 6:Stack overflow

            Console.WriteLine(LogLine.OutputForShortLog(LogLevel.Fatal, "Kernel panic"));
            // Esperado: 42:Kernel panic
        }
    }
