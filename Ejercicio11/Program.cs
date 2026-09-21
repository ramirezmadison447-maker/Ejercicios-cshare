
abstract class Character 
{   

    public override string ToString()
    {
        return $"Character is a {this.GetType().Name}";
    }
    public virtual bool Vulnerable()
    {
        return false; 
    }
}

class Warrior : Character
{
    public int DamagePoints(Character target)
    {
        return target.Vulnerable() ? 10 : 6;
    }
}

class Wizard : Character
{
    private bool isSpellReady = false;

    public void PrepareSpell()
    {
        isSpellReady = true;
    }

    public override bool Vulnerable()
    {
        if (isSpellReady)
        {
            return false;
        }
        return true;
    }

    public int DamagePoints(Character target)
    {
        return isSpellReady ? 12 : 3;
    }
}

public class Ejecutable
{
    public static void Main(string[] args)
    {
        var warrior = new Warrior().ToString();
        Console.WriteLine(warrior);

        var wizard = new Wizard();
        wizard.PrepareSpell();

        var wizard1 = new Wizard();
        Console.WriteLine(wizard1.Vulnerable()); // True - Porque el hechizo no esta listo y el mago es vulnerable.
        wizard1.PrepareSpell();
       Console.WriteLine(wizard1.Vulnerable()); // False - Ya el mago no es vulnerable el hechizo se preparo.


        var wizard2 = new Wizard();
        var warrior1 = new Warrior();
        Console.WriteLine(wizard2.DamagePoints(warrior1)); // Aqui me devuelve 3 pq no se ha preparado el hechizo 
        wizard2.PrepareSpell();
        Console.WriteLine(wizard2.DamagePoints(warrior1)); // Aqui me devuelve 12 pq el hechizo ya se preparo.


        var warrior2 = new Warrior();
        var wizard3 = new Wizard();
        Console.WriteLine(warrior2.DamagePoint(wizard3)); // Esto debe de arrojar: 10 Porque mi oponente en este caso Wizar todavia no tiene el hechizo preparado por lo tanto esta debil y el warrior es mas fuerte
        wizard3.PrepareSpell();
        Console.WriteLine(warrior2.DamagePoint(wizard3)); // Ahora me da: 6, Porque el mago se tomo su pocion y es mas fuerte que el Warrior por lo tanto retorna 6.
    }
}