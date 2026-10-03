using System;

public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string operation)
    {
        int result;

        switch (operation)
        {
            case "+":
                result = operand1 + operand2;
                break;

            case "*":
                result = operand1 * operand2;
                break;

            case "/":
                try
                {
                    result = operand1 / operand2;
                }
                catch (DivideByZeroException)
                {
                    return "Division by zero is not allowed.";
                }
                break;

            case null:
                throw new ArgumentNullException(nameof(operation));
                                                             
            case "":
                throw new ArgumentException("La operación no puede estar vacía.", nameof(operation));

            default:
                throw new ArgumentOutOfRangeException(nameof(operation), $"Operación desconocida: {operation}");
        }

        return $"{operand1} {operation} {operand2} = {result}";
    }
}

public class Ejecutador
{
    public static void Main(string[] args)
    {
        Console.WriteLine(SimpleCalculator.Calculate(10, 5, "+"));
        Console.WriteLine(SimpleCalculator.Calculate(10, 5, "*"));
        Console.WriteLine(SimpleCalculator.Calculate(10, 5, "/"));
        //Probando excepciones.
        Console.WriteLine("================================");
        Console.WriteLine(SimpleCalculator.Calculate(10, 0, "/"));
        Console.WriteLine("=====================================");                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
        try
        {
            Console.WriteLine(SimpleCalculator.Calculate(10, 5, null));
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine("Error null: " + ex.Message);
        }

        try
        {
            Console.WriteLine(SimpleCalculator.Calculate(10, 5, ""));
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error vacío: " + ex.Message);
        }

        try
        {
            Console.WriteLine(SimpleCalculator.Calculate(10, 5, "-"));
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("Error signo desconocido: " + ex.Message);
        }



        Console.ReadKey();

    }
}