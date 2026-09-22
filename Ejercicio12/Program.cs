
public class Character
{
    public string Class { get; set; }

    public int Level { get; set; }

    public int HitPoints { get; set; }

}

public class Destination
{
    public string Name { get; set; }

    public int Inhabitants { get; set; }
}



public enum TravelMethod
{
    Walking,
    Horseback
}
public static class GameMaster
{
    public static string Describe(Character character) 
    {
        return $"You're a level {character.Level} {character.Class} with {character.HitPoints} hit points.";
    }

    public static string Describe(Destination destination)
    {
        return $"You've arrived at {destination.Name}, which has {destination.Inhabitants} inhabitants.";
    }


    public static string Describe(TravelMethod travelMethod)
    {
        if (travelMethod == TravelMethod.Walking)
        {
            return "You're traveling to your destination by walking.";
        }
        return "You're traveling to your destination on horseback.";
    }   

    public static string Describe(Character character, TravelMethod travelMethod, Destination destination)
    {
        return $"{Describe(character)} {Describe(travelMethod)} {Describe(destination)} ";
    }

    public static string Describe(Character character, Destination destination)
    {
        return $"{Describe(character)} {Describe(TravelMethod.Walking)} {Describe(destination)}";
    }
}


public class Ejecutable
{
    public static void Main(string[] args)
    {
        var c = new Character();
        c.Class = "Wizard";
        c.Level = 4;
        c.HitPoints = 28;

        Console.WriteLine(GameMaster.Describe(c));

        var d = new Destination();
        d.Name = "Muros";
        d.Inhabitants = 732;

        Console.WriteLine(GameMaster.Describe(d));


        Console.WriteLine(GameMaster.Describe(TravelMethod.Walking));
        Console.WriteLine(GameMaster.Describe(TravelMethod.Horseback));

        Console.WriteLine(GameMaster.Describe(c, TravelMethod.Horseback, d));

        Console.WriteLine(GameMaster.Describe(c, d));
    }
}