// EJERCICIO 1: Escribe un programa en C# que imprima "Hello, World!" en la consola.
//Console.WriteLine("Hello, World!");



//Ejercicio 2

namespace Cookinglasagna
{
    public class Lasagna
    {
        static void Main(string[] args)
        {


            var lasagna = new Lasagna();
            Console.WriteLine(lasagna.ExpectedMinutesInOven());
            Console.WriteLine(lasagna.ElapsedTimeInMinutes(3, 20));

        }

        public int ExpectedMinutesInOven()
        {
            return 40;
        }

        public int RemainingMinutesInOven(int actualMinutesInOven)
        {
            return ExpectedMinutesInOven() - actualMinutesInOven;
        }

        public int PreparationTimeInMinutes(int numberOfLayers)
        {
            return numberOfLayers * 2;
        }

        public int ElapsedTimeInMinutes(int numberOfLayers, int actualMinutesInOven)
        {
            return (numberOfLayers * 2) + actualMinutesInOven;
        }



    }


}
