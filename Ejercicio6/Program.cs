public class BirdCount
{
    private readonly int[] _birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        _birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        return new[] { 0, 2, 5, 3, 7, 8, 4 };
    }

    public int Today()
    {
        return _birdsPerDay[_birdsPerDay.Length - 1];
    }

    public void IncrementTodaysCount()
    {
        _birdsPerDay[_birdsPerDay.Length - 1]++;
    }

    public bool HasDayWithoutBirds()
    {
        foreach (int count in _birdsPerDay)
        {
            if (count == 0)
            {
                return true;
            }
        }
        return false;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int total = 0;
        for (int i = 0; i < numberOfDays; i++)
        {
            total += _birdsPerDay[i];
        }
        return total;
    }

    public int BusyDays()
    {
        int busy = 0;
        foreach (int count in _birdsPerDay)
        {
            if (count >= 5)
            {
                busy++;
            }
        }
        return busy;
    }


    public static void Main(string[] args)
    {
        var birdsPerDay = new[] { 2, 5, 0, 7, 4, 1 };
        var birdCount = new BirdCount(birdsPerDay);
        
        Console.WriteLine(birdCount.HasDayWithoutBirds());
        Console.WriteLine("====================");

        foreach (int count in BirdCount.LastWeek())
        {
            Console.WriteLine(count);
        }
        Console.WriteLine("====================");
        Console.WriteLine(birdCount.Today());
        birdCount.IncrementTodaysCount();
        Console.WriteLine("====================");
        Console.WriteLine(birdCount.Today());
        Console.WriteLine("====================");
        Console.WriteLine(birdCount.HasDayWithoutBirds());
        Console.WriteLine("=============================");
        Console.WriteLine(birdCount.CountForFirstDays(4));


    }

}