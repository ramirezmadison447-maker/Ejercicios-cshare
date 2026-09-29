
public interface IRemoteControlCar
{
    int DistanceTravelled { get; }
    void Drive();
}



public class ProductionRemoteControlCar : IRemoteControlCar, IComparable <ProductionRemoteControlCar>
{
    public int NumberOfVictories { get; set; }
    public int DistanceTravelled { get; private set; }
    public void Drive()
    {
        DistanceTravelled += 1;
    }

    public int CompareTo(ProductionRemoteControlCar other)
    {
        return this.NumberOfVictories.CompareTo(other.NumberOfVictories);
    }

}


public class ExperimentalRemoteControlCar : IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }

    public void Drive()
    {
        DistanceTravelled += 2;
    }
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car)
    {
        for (int i = 0; i < 10; i++)
        {
            car.Drive();
        }
    }

    public static ProductionRemoteControlCar[] GetRankedCars(params ProductionRemoteControlCar[] cars)
    {
        
        Array.Sort(cars);
        return cars;
    }
}




public class Ejecutable
{
    public static void Main(string[] args)
    {
        var prod = new ProductionRemoteControlCar();
        TestTrack.Race(prod);
        Console.WriteLine($"Production distance: {prod.DistanceTravelled}");   // 10

        var exp = new ExperimentalRemoteControlCar();
        TestTrack.Race(exp);
        Console.WriteLine($"Experimental distance: {exp.DistanceTravelled}");  // 20

        IRemoteControlCar carroGenerico = new ProductionRemoteControlCar();
        TestTrack.Race(carroGenerico);
        Console.WriteLine($"Via interface: {carroGenerico.DistanceTravelled}");

        Console.WriteLine("=====================================");

        var prc1 = new ProductionRemoteControlCar();
        var prc2 = new ProductionRemoteControlCar();
        var prc3 = new ProductionRemoteControlCar();
        prc1.NumberOfVictories = 3;
        prc2.NumberOfVictories = 2;
        prc3.NumberOfVictories = 5;

        var rankings = TestTrack.GetRankedCars(prc1, prc2, prc3);
        foreach (var car in rankings)
        {
            Console.WriteLine($"Victorias: {car.NumberOfVictories}");
        }


        Console.ReadKey();

    }
}
