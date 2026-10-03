using System;
using System.Globalization;

public class WeighingMachine
{
    // Campo privado: aquí se guarda el peso "de verdad"
    private double weight;

    // 1. Precision: solo lectura, se fija en el constructor
    public int Precision { get; }

    // 4 y 5. TareAdjustment: lectura y escritura, empieza en 5
    public double TareAdjustment { get; set; } = 5;

    // Constructor
    public WeighingMachine(int precision)
    {
        Precision = precision;
    }

    // 2 y 3. Weight: lectura y escritura, pero rechaza negativos
    public double Weight
    {
        get { return weight; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "El peso no puede ser negativo.");
            }
            weight = value;
        }
    }

    // 6. DisplayWeight: solo lectura, se calcula cada vez que se pide
    public string DisplayWeight
    {
        get
        {
            double ajustado = weight - TareAdjustment;
            return ajustado.ToString("F" + Precision, CultureInfo.InvariantCulture) + " kg";
        }
    }
}

public class Ejecutador
{
    public static void Main(string[] args)
    {
        // ===== Tarea 1: Precision desde el constructor =====
        Console.WriteLine("=== Tarea 1: Precision ===");
        WeighingMachine bascula = new WeighingMachine(precision: 3);
        Console.WriteLine($"Precision: {bascula.Precision}");

        // ===== Tarea 5: Tara por defecto =====
        Console.WriteLine("\n=== Tarea 5: Tara por defecto ===");
        Console.WriteLine($"TareAdjustment inicial: {bascula.TareAdjustment}");

        // ===== Tarea 2: Leer y escribir el peso =====
        Console.WriteLine("\n=== Tarea 2: Weight ===");
        bascula.Weight = 60.5;
        Console.WriteLine($"Weight: {bascula.Weight}");

        // ===== Tarea 3: Peso negativo =====
        Console.WriteLine("\n=== Tarea 3: Peso negativo ===");
        try
        {
            bascula.Weight = -10;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("Error atrapado: " + ex.Message);
        }
        Console.WriteLine($"Weight después del error: {bascula.Weight}");

        // ===== Tarea 4: Cambiar la tara (acepta negativos) =====
        Console.WriteLine("\n=== Tarea 4: TareAdjustment ===");
        bascula.TareAdjustment = -10.6;
        Console.WriteLine($"TareAdjustment: {bascula.TareAdjustment}");

        // ===== Tarea 6: DisplayWeight =====
        Console.WriteLine("\n=== Tarea 6: DisplayWeight ===");
        bascula.Weight = 60.567;
        bascula.TareAdjustment = 10;
        Console.WriteLine($"DisplayWeight: {bascula.DisplayWeight}");

        // DisplayWeight se recalcula solo
        bascula.Weight = 100;
        Console.WriteLine($"Tras cambiar Weight a 100: {bascula.DisplayWeight}");

        // ===== Extra: dos básculas independientes =====
        Console.WriteLine("\n=== Extra: dos instancias ===");
        WeighingMachine otra = new WeighingMachine(precision: 1);
        otra.Weight = 80;
        Console.WriteLine($"bascula -> {bascula.DisplayWeight}");
        Console.WriteLine($"otra    -> {otra.DisplayWeight}");
    }
}
