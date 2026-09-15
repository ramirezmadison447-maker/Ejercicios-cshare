
public class AssemblyLine
{
    public static void Main(string[] args)
    {
        Console.WriteLine(AssemblyLine.SuccessRate(6));

        Console.WriteLine(AssemblyLine.ProductionRatePerHour(6));

        Console.WriteLine(AssemblyLine.WorkingItemsPerMinute(6));

    }

    public static double SuccessRate(int speed)
    {
        if (speed == 0)
        {
            return 0.0;
        }
        else if (speed >= 1 && speed <= 4)
        {
            return 1.0;
        }
        else if (speed >= 5 && speed <= 8)
        {
            return 0.90;
        }
        else if (speed == 9)
        {
            return 0.80;
        }
        else if (speed == 10)
        {
            return 0.77;
        }
        else
        {
            return -1;
        }
    }

    public static double ProductionRatePerHour(int speed)
    {
        double saveSuccessRate = SuccessRate(speed);

        double idealProduction = speed * 221;

        return idealProduction * saveSuccessRate;

    }

    public static int WorkingItemsPerMinute(int speed)
    {
        double carPerMinutes = ProductionRatePerHour(speed) / 60;

        int convertingIntoInt = (int)carPerMinutes;

        return convertingIntoInt;
    }

}


