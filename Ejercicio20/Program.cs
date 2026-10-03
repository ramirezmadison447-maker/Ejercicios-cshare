using System;
using System.Collections.Generic;

public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    // Dos caras son iguales si tienen el mismo color de ojos y el mismo ancho de filtrum
    public override bool Equals(object? obj)
    {
        if (obj is FacialFeatures other)
        {
            return EyeColor == other.EyeColor && PhiltrumWidth == other.PhiltrumWidth;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(EyeColor, PhiltrumWidth);
    }
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }

    // Dos identidades son iguales si tienen el mismo email y la misma cara
    public override bool Equals(object? obj)
    {
        if (obj is Identity other)
        {
            return Email == other.Email && FacialFeatures.Equals(other.FacialFeatures);
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Email, FacialFeatures);
    }
}

public class Authenticator
{
    private readonly Identity admin = new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m));

    private readonly HashSet<Identity> registered = new HashSet<Identity>();

    // Tarea 1
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB)
    {
        return faceA.Equals(faceB);
    }

    // Tarea 2
    public bool IsAdmin(Identity identity)
    {
        return identity.Equals(admin);
    }

    // Tarea 3
    public bool Register(Identity identity)
    {
        return registered.Add(identity);
    }

    // Tarea 4
    public bool IsRegistered(Identity identity)
    {
        return registered.Contains(identity);
    }

    // Tarea 5
    public static bool AreSameObject(Identity identityA, Identity identityB)
    {
        return ReferenceEquals(identityA, identityB);
    }
}

public class Ejecutador
{
    public static void Main(string[] args)
    {
        // ===== Tarea 1 =====
        Console.WriteLine("=== Tarea 1: AreSameFace ===");
        var caraA = new FacialFeatures("green", 0.9m);
        var caraB = new FacialFeatures("green", 0.9m);
        var caraC = new FacialFeatures("blue", 0.9m);
        Console.WriteLine($"A vs B (mismos datos):  {Authenticator.AreSameFace(caraA, caraB)}");
        Console.WriteLine($"A vs C (ojos distintos): {Authenticator.AreSameFace(caraA, caraC)}");

        // ===== Tarea 2 =====
        Console.WriteLine("\n=== Tarea 2: IsAdmin ===");
        var auth = new Authenticator();
        var posibleAdmin = new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m));
        var impostor = new Identity("admin@exerc.ism", new FacialFeatures("brown", 0.9m));
        Console.WriteLine($"Admin real: {auth.IsAdmin(posibleAdmin)}");
        Console.WriteLine($"Impostor (otros ojos): {auth.IsAdmin(impostor)}");

        // ===== Tarea 3 =====
        Console.WriteLine("\n=== Tarea 3: Register ===");
        var madison = new Identity("madison@mail.com", new FacialFeatures("brown", 0.8m));
        var madisonCopia = new Identity("madison@mail.com", new FacialFeatures("brown", 0.8m));
        Console.WriteLine($"Registrar madison:        {auth.Register(madison)}");
        Console.WriteLine($"Registrar madison otra vez: {auth.Register(madisonCopia)}");

        // ===== Tarea 4 =====
        Console.WriteLine("\n=== Tarea 4: IsRegistered ===");
        var desconocido = new Identity("nadie@mail.com", new FacialFeatures("gray", 0.5m));
        Console.WriteLine($"¿madison registrada?     {auth.IsRegistered(madisonCopia)}");
        Console.WriteLine($"¿desconocido registrado? {auth.IsRegistered(desconocido)}");

        // ===== Tarea 5 =====
        Console.WriteLine("\n=== Tarea 5: AreSameObject ===");
        Console.WriteLine($"madison vs madison:      {Authenticator.AreSameObject(madison, madison)}");
        Console.WriteLine($"madison vs madisonCopia: {Authenticator.AreSameObject(madison, madisonCopia)}");
        Console.WriteLine($"...pero ¿Equals?         {madison.Equals(madisonCopia)}");
    }
}