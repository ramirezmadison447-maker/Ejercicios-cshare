public class LogLine
{
    public static void Main(string[] args)
    {
        //var result = LogLine.Message("[ERROR]: Invalid operation");
        //Console.WriteLine(result);


        var result = LogLine.Message("[WARNING]:  Disk almost full\r\n");
        Console.WriteLine(result);
        Console.WriteLine("====================================");

        var result2 = LogLine.LogLevel("[ERROR]: Invalid operation");
        Console.WriteLine(result2);
        Console.WriteLine("====================================");

        var result3 = LogLine.Reformat("[INFO]: Operation completed");
        Console.WriteLine(result3);
        Console.WriteLine("====================================");
        Console.WriteLine(LogLine.Reformat("[WARNING]: Disk almost full"));
    }

    public static string Message(string line)
    {
        int pos = line.IndexOf("]: ");
        string afte = line.Substring(pos + 3);
        return afte.Trim();
        
    }

    public static string LogLevel(string line)
    {
        int start = line.IndexOf('[') + 1;
        int end = line.IndexOf("]");
        int length = end - start;
        string result = line.Substring(start, length);
        return result.ToLower();

    }

    public static string Reformat(string line)
    {
        string messa = Message(line);
        string log = LogLevel(line);

        return $"{messa} ({log})";
    }

}