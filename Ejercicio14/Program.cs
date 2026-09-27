// Using Namespaces.

using System;
using System.Net.NetworkInformation;
using Red = RedRemoteControlCarTeam;
using Blue = BlueRemoteControlCarTeam;

namespace RedRemoteControlCarTeam
{
    
    public class Motor
    {
        public int Speed { get; private set; }

        public void Accelerate()
        {
            Speed++;
        }
    }

    public class Telemetry
    {
        public string Report(int speed)
        {
            return $"[RED] Current speed: {speed}";
        }
    }

    public class RemoteControlCar
    {
        private Motor motor = new Motor();
        private Telemetry telemetry = new Telemetry();

        public void Drive()
        {
            motor.Accelerate();
        }

        public string GetStatus()
        {
            return telemetry.Report(motor.Speed);
        }
    }
}

namespace BlueRemoteControlCarTeam
{
    public class Motor
    {
        public int Speed { get; private set; }

        public void Accelerate()
        {
            Speed += 2;   // el equipo azul acelera diferente
        }
    }

    public class Telemetry
    {
        public string Report(int speed)
        {
            return $"[BLUE] Current speed: {speed}";
        }
    }

    public class RemoteControlCar
    {
        private Motor motor = new Motor();
        private Telemetry telemetry = new Telemetry();

        public void Drive()
        {
            motor.Accelerate();
        }

        public string GetStatus()
        {
            return telemetry.Report(motor.Speed);
        }
    }
}

public class Ejecutable
{
    public static void Main(string[] args)
    {
        
        var redCar = new Red.RemoteControlCar();
        redCar.Drive();
        redCar.Drive();
        Console.WriteLine(redCar.GetStatus());   // [RED] Current speed: 2

        var blueCar = new Blue.RemoteControlCar();
        blueCar.Drive();
        blueCar.Drive();
        Console.WriteLine(blueCar.GetStatus());  // [BLUE] Current speed: 4
    }
}
