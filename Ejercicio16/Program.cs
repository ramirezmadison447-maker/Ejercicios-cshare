
public static class DialingCodes
{
    // 1. Diccionario vacío
    public static Dictionary<int, string> GetEmptyDictionary()
    {
        return new Dictionary<int, string>();
    }

    // 2. Diccionario precargado
    public static Dictionary<int, string> GetExistingDictionary()
    {
        return new Dictionary<int, string>
        {
            { 1, "United States of America" },
            { 55, "Brazil" },
            { 91, "India" }
        };
    }

    // 3. Crear diccionario y agregar un país
    public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName)
    {
        var dict = new Dictionary<int, string>();
        dict.Add(countryCode, countryName);
        return dict;
    }

    // 4. Agregar país a un diccionario existente
    public static Dictionary<int, string> AddCountryToExistingDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        existingDictionary.Add(countryCode, countryName);
        return existingDictionary;
    }

    // 5. Obtener nombre del país (o "" si no existe)
    public static string GetCountryNameFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        if (existingDictionary.ContainsKey(countryCode))
        {
            return existingDictionary[countryCode];
        }
        return "";
    }

    // 6. ¿Existe el código?
    public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int countryCode)
    {
        return existingDictionary.ContainsKey(countryCode);
    }

    // 7. Actualizar nombre (solo si el código existe)
    public static Dictionary<int, string> UpdateDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        if (existingDictionary.ContainsKey(countryCode))
        {
            existingDictionary[countryCode] = countryName;
        }
        return existingDictionary;
    }

    // 8. Eliminar país
    public static Dictionary<int, string> RemoveCountryFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        existingDictionary.Remove(countryCode);
        return existingDictionary;
    }

    // 9. Nombre más largo
    public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
    {
        string longest = "";
        foreach (string name in existingDictionary.Values)
        {
            if (name.Length > longest.Length)
            {
                longest = name;
            }
        }
        return longest;
    }
}

public class Ejecutable
{
    // Método de ayuda: imprime un diccionario completo
    static void Mostrar(Dictionary<int, string> dict)
    {
        if (dict.Count == 0)
        {
            Console.WriteLine("   (vacío)");
            return;
        }
        foreach (KeyValuePair<int, string> par in dict)
        {
            Console.WriteLine($"   {par.Key} => {par.Value}");
        }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("1. GetEmptyDictionary:");
        Mostrar(DialingCodes.GetEmptyDictionary());

        Console.WriteLine("\n2. GetExistingDictionary:");
        Mostrar(DialingCodes.GetExistingDictionary());

        Console.WriteLine("\n3. AddCountryToEmptyDictionary(44, \"United Kingdom\"):");
        Mostrar(DialingCodes.AddCountryToEmptyDictionary(44, "United Kingdom"));

        Console.WriteLine("\n4. AddCountryToExistingDictionary(existente, 44, \"United Kingdom\"):");
        Mostrar(DialingCodes.AddCountryToExistingDictionary(
            DialingCodes.GetExistingDictionary(), 44, "United Kingdom"));

        Console.WriteLine("\n5. GetCountryNameFromDictionary:");
        string encontrado = DialingCodes.GetCountryNameFromDictionary(DialingCodes.GetExistingDictionary(), 55);
        string noEncontrado = DialingCodes.GetCountryNameFromDictionary(DialingCodes.GetExistingDictionary(), 999);
        Console.WriteLine($"   código 55  => \"{encontrado}\"");
        Console.WriteLine($"   código 999 => \"{noEncontrado}\"");

        Console.WriteLine("\n6. CheckCodeExists:");
        Console.WriteLine($"   ¿existe 55?  {DialingCodes.CheckCodeExists(DialingCodes.GetExistingDictionary(), 55)}");
        Console.WriteLine($"   ¿existe 999? {DialingCodes.CheckCodeExists(DialingCodes.GetExistingDictionary(), 999)}");

        Console.WriteLine("\n7. UpdateDictionary(existente, 1, \"Les États-Unis\"):");
        Mostrar(DialingCodes.UpdateDictionary(DialingCodes.GetExistingDictionary(), 1, "Les États-Unis"));
        Console.WriteLine("   UpdateDictionary(existente, 999, \"Newlands\")  -> no debe cambiar:");
        Mostrar(DialingCodes.UpdateDictionary(DialingCodes.GetExistingDictionary(), 999, "Newlands"));

        Console.WriteLine("\n8. RemoveCountryFromDictionary(existente, 91):");
        Mostrar(DialingCodes.RemoveCountryFromDictionary(DialingCodes.GetExistingDictionary(), 91));

        Console.WriteLine("\n9. FindLongestCountryName:");
        Console.WriteLine($"   \"{DialingCodes.FindLongestCountryName(DialingCodes.GetExistingDictionary())}\"");
        Console.WriteLine($"   con diccionario vacío: \"{DialingCodes.FindLongestCountryName(DialingCodes.GetEmptyDictionary())}\"");
    }
}
