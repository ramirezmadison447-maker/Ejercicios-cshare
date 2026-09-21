public class RemoteControlCar
{
    private int _speed;
    private int _batteryDrain;

    private int _carsBattery = 100;

    private int _distanceDriven = 0;

    public RemoteControlCar(int speed, int batteryDrain)
    {
        this._speed = speed;
        this._batteryDrain = batteryDrain;
    }

    public void Drive()
    {
        if (!BatteryDrained())
        {
            _carsBattery -= _batteryDrain;
            _distanceDriven += _speed;

        }
    }

    public int ShowBatteryLevel()
    {
        return _carsBattery;
    }
    public int DistanceDriven()
    {
        return _distanceDriven;

    }

    public bool BatteryDrained()
    {
        return _carsBattery < _batteryDrain;
    }
    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50, 4);
    }

    public int Speed() { return _speed; }
    public int BatteryDrain() { return _batteryDrain;}
    public int CurrentBattery() { return _carsBattery; }

    
}

public class RaceTrack
{
    private int _distance;

    public RaceTrack(int distance)
    {
       this._distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        double vueltasPosibles = (double)car.CurrentBattery() / car.BatteryDrain();
        double distanciaMaxima = vueltasPosibles * car.Speed();
        return distanciaMaxima >= _distance;
    }
  
}




public class Ejecutable
{
    public static void Main(string[] args)
    {

        RemoteControlCar remoteControlCar = new RemoteControlCar(5, 30);

        remoteControlCar.Drive();
        remoteControlCar.Drive();
        remoteControlCar.Drive();
        remoteControlCar.Drive();

        Console.WriteLine(remoteControlCar.DistanceDriven());
        Console.WriteLine(remoteControlCar.ShowBatteryLevel());
        Console.WriteLine(remoteControlCar.BatteryDrained());
        var car = RemoteControlCar.Nitro();
        car.Drive();
        Console.WriteLine (car.DistanceDriven());
        var race1 = new RaceTrack(100);
        Console.WriteLine(race1.TryFinishTrack(car));  // Aqui estoy aplicando el metodo TryFinishTrack Utilizando el metodo ya creado Nitro: esto da TRUE

        var car1 = new RemoteControlCar(5, 2);
        var race = new RaceTrack(100);
        Console.WriteLine(race.TryFinishTrack(car1));  //  Este me dara: True
        
        var slowCar = new RemoteControlCar(3, 20);
        var longRace = new RaceTrack(16);
        Console.WriteLine(longRace.TryFinishTrack(slowCar));  //  Y esto me dara: False
        
    }
}



