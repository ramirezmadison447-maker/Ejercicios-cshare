public class RemoteControlCar
{
    private int _battery = 100;
    private int _distance = 0;
    
    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return $"Driven {_distance} meters";
    }

    public string BatteryDisplay()
    {
        if (_battery == 0)
        {
            return "Battery empty";

        }
        else
        {
            return $"Battery at {_battery}%";

        }
    }

    public void Drive()
    {
        if (_battery > 0)
        {
            _distance += 20;
            _battery -= 1;
        }

    }

}




class Ejecutable
{
    public static void Main(string[] args)
    {

        var car = RemoteControlCar.Buy();
        
        for (int i = 0; i < 100; i++)
        {
            car.Drive();
            car.Drive();
            car.Drive();
            car.Drive();
            car.Drive();
        }
        Console.WriteLine(car.DistanceDisplay());
        Console.WriteLine(car.BatteryDisplay());

    }
}