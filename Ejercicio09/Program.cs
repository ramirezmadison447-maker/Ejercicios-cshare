public class Languages
{
    public static List<string> NewList()
    {
        return new List<string>();
    }

    public static List<string> GetExistingLanguages()
    {
        return new List<string> { "C#", "Python", "JavaScript" };
    }

    public static List<string> AddLanguage(List<string> program, string newProgram)
    {
        program.Add(newProgram);
        return program;
    }

    public static int CountLanguages(List<string> languages)
    {
        return languages.Count;
    }

    public static bool HasLanguage(List<string> languages, string confirmLanguages)
    {
        return languages.Contains(confirmLanguages);
    }

    public static List<string> ReverseList(List<string> languages)
    {
        languages.Reverse();
        return languages;
    }

    public static bool IsExciting(List<string> languages)
    {
        bool caminoA = languages[0] == "C#";
        bool caminoB = (languages.Count == 2 || languages.Count == 3) && languages[1] == "C#";
        return caminoA || caminoB;
    }

    public static List<string> RemoveLanguage(List<string> languages, string removeLanguages)
    {
         languages.Remove(removeLanguages);
        return languages;
    }

    public static bool IsUnique(List<string> languages)
    {
        return languages.Count == languages.Distinct().Count();
    }

}


public class Ejecutable
{
    public static void Main(string[] args)
    {

        
        Console.WriteLine(string.Join(", ", Languages.GetExistingLanguages()));
        Console.WriteLine(string.Join(", ", Languages.AddLanguage(Languages.GetExistingLanguages(), "Java")));
        Console.WriteLine(Languages.CountLanguages(Languages.GetExistingLanguages()));
        Console.WriteLine(Languages.HasLanguage(Languages.GetExistingLanguages(), "Python"));
        Console.WriteLine(string.Join(", ",Languages.ReverseList(Languages.GetExistingLanguages())));
        Console.WriteLine( Languages.IsExciting(Languages.GetExistingLanguages()));
        Console.WriteLine(string.Join(", ", Languages.RemoveLanguage(Languages.GetExistingLanguages(), "Python")));
        var listaConDuplicado =  Languages.AddLanguage(Languages.GetExistingLanguages(), "C#");
        Console.WriteLine( Languages.IsUnique(listaConDuplicado));

    }
    

}
