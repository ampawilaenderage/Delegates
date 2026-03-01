using System;
using static Delegates;

class Delegates
{
    //  Delegate definition
    public delegate int FreizeitCallback(string text, int number);
    public delegate void MultiCastDelegates();
   
    static int Lesen(string buchtitel, int kapitel)
    {
        int dauer = 2;
        Console.WriteLine($"Ich lese Kapitel {kapitel} des Buchs {buchtitel}.");
        return dauer;
    }

    static int BlumenGiessen(string blume, int milliliter)
    {
        int anzahlBlumen = 3;
        Console.WriteLine($"Ich gieße jede {blume} mit {milliliter} ml Wasser.");
        return anzahlBlumen;
    }

    static int FilmGucken(string filmtitel, int anzahlFreunde)
    {
        int besucher = 67;
        Console.WriteLine($"Ich gucke im Kino mit {anzahlFreunde} Freund{(anzahlFreunde != 1 ? "en" : "")} den Film {filmtitel}.");
        return besucher;
    }

    static void Multicast1() {
        Console.WriteLine("M1");
    }
    static void Multicast2()
    {
        Console.WriteLine("M2");
    }


    static void Main(string[] args)
    {
        // Using delegate variable
        FreizeitCallback myCallback;
        
        // Delegate Multicast
        MultiCastDelegates multiCast1 = new MultiCastDelegates(Multicast1);
        MultiCastDelegates multiCast2 = new MultiCastDelegates(Multicast2);
        MultiCastDelegates multiCast = (MultiCastDelegates)MultiCastDelegates.Combine(multiCast1, multiCast2);
        multiCast();

        myCallback = Lesen;
        int result1 = Freizeit.Beschaeftigen(myCallback, "C# Grundlagen", 3);
     
        FreizeitCallback myCallback1 = new FreizeitCallback(Lesen);
        int result12 = Freizeit.Beschaeftigen(myCallback1, "C# Grundlagen", 3);

        Console.WriteLine("Ergebnis: " + result1);

        myCallback = BlumenGiessen;
        int result2 = Freizeit.Beschaeftigen(myCallback, "Rose", 200);
        Console.WriteLine("Ergebnis: " + result2);

        myCallback = FilmGucken;
        int result3 = Freizeit.Beschaeftigen(myCallback, "Matrix", 2);
        Console.WriteLine("Ergebnis: " + result3);



        Console.WriteLine("--- Anonyme Methode ---");

        int result = Freizeit.Beschaeftigen(
            delegate (string text, int number)
            {
                Console.WriteLine($"Ich mache {number}x {text} (anonyme Methode).");
                return number * 5; // example calculation
            },
            "Sport",
            4
        );

        Console.WriteLine("Ergebnis: " + result);

        Console.ReadLine();
    }
}

static class Freizeit
{
    public static int Beschaeftigen(FreizeitCallback callback, string text, int number)
    {
        return callback(text, number);
    }
}