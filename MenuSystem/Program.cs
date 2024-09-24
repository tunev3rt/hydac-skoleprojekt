using System;
using System.Runtime.CompilerServices;

namespace Hydac;

class Program
{
    private static void Main()
    {
        //Variabler
        string medarbejdernavn = " ";
        bool medarbejderlogin = false;
        string valg1 = " ";
        bool startmenu = true;
        bool medarbejdermenu = false;
        bool guestmenu = false;
        bool erclocketind = false;
        string person = "";
        int counter = 1;

        while (startmenu == true)
        {
            Console.Clear();
            Console.WriteLine("Vælg om du er en gæst eller medarbejder.\n\n1. Medarbejder \n2. Gæst\n\n(Tag et vælg eller indtast 0 for at afslutte.)");
            valg1 = Console.ReadLine();
            switch (valg1)
            {
                case "1": //Medarbejder login
                    Medarbejderlogin medarbejderlogininstans = new Medarbejderlogin();
                    Console.Clear();
                    Console.Write("MEDARBEJDER LOGIN\n\nIndtast din adgangskode...");
                    medarbejdernavn = medarbejderlogininstans.login(Console.ReadLine());
                    if (medarbejdernavn == " ") // Hvis koden er forkert
                    {
                        Console.Clear();
                        Console.WriteLine("Forkert adgangskode.\n\n(Tryk enter for at gå tilbage)");
                        Console.Read();
                        break;
                    }
                    else // Hvis koden er korrekt
                    {
                        medarbejderlogin = true;
                        startmenu = false;
                        break;
                    }
                case "2": //Gæste login
                    startmenu = false;
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default: //Forkert input
                    break;
            }
        }
        if (medarbejderlogin == true) // Åbner medarbejder menuen
        {
            medarbejdermenu = true;
            while (medarbejdermenu == true)
            {
                Console.Clear();
                Console.WriteLine($"Velkommen: {medarbejdernavn} - vælg hvad du vil.\n\n1. Clock ind/ud\n2. Se loggen\n3. Log ud");
                valg1 = Console.ReadLine();
                switch (valg1)
                {
                    case "1": //Clock ind/ud
                        Loggen medarbejderstatusinstans = new Loggen();
                        Console.Clear();
                        erclocketind = medarbejderstatusinstans.loggen(medarbejdernavn, 0);
                        if (erclocketind == true) // Clock ud koden
                        {
                            bool medarbejdermenu2 = true;
                            while (medarbejdermenu2 == true)
                            {
                                Console.WriteLine($"CLOCK UD for: {medarbejdernavn}\n\nVil du clocke ud? (y/n)");
                                valg1 = Console.ReadLine();
                                switch (valg1)
                                {
                                    case "y":
                                        medarbejdermenu2 = false;
                                        medarbejderstatusinstans.loggen(medarbejdernavn, 1);
                                        break;
                                    case "n":
                                        medarbejdermenu2 = false;
                                        break;
                                    default:
                                        medarbejdermenu2 = false;
                                        break;
                                }
                            }
                        }
                        else // Clock ind koden
                        {
                            bool medarbejdermenu2 = true;
                            while (medarbejdermenu2 == true)
                            {
                                Console.Clear();
                                Console.WriteLine($"CLOCK IND for: {medarbejdernavn}\n\nVil du clocke ind? (y/n)");
                                valg1 = Console.ReadLine();
                                switch (valg1)
                                {
                                    case "y":
                                        medarbejdermenu2 = false;
                                        medarbejderstatusinstans.loggen(medarbejdernavn, 1);
                                        break;
                                    case "n":
                                        medarbejdermenu2 = false;
                                        break;
                                    default:
                                        medarbejdermenu2 = false;
                                        break;
                                }
                            }
                        }
                        break;
                    case "2": //Se loggen
                        Console.Clear();
                        Loggen loghent = new Loggen();
                        string logfil = loghent.hentloggen();
                        Console.WriteLine(logfil);
                        Console.Read();
                        break;
                    case "3": //Log ud
                        Main();
                        break;
                    default:
                        break;
                }
            }
        }
        else // Åbner gæstemenuen
        {
            guestmenu = true;
            while (guestmenu == true)
            {
                Loggen guesttillog = new Loggen();
                Console.Clear();
                Console.WriteLine("GÆSTE MENUEN\n\n1. Meld din ankomst\n2. Meld afgang\n\n(Tryk enter for at gå tilbage igen)");
                valg1 = Console.ReadLine();
                switch (valg1)
                {
                    case "1": // Gæst melder ankomst
                        Console.Clear();
                        Console.WriteLine("Meld ankomst\n\nIndtast dit fulde navn.\n\n(Tryk enter for at gå tilbage)");
                        person = Console.ReadLine();
                        if (person == "")
                            break;
                        if (person == " ")
                            break;
                        Console.Clear();
                        Console.WriteLine("Meld ankomst\n\nHvilket firma besøger du fra?");
                        string firma = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Meld ankomst\n\nHvem var ansvarlig for dit besøg?");
                        string ansvarlig = Console.ReadLine();
                        guesttillog.guest($"Navn: {person} fra firma: {firma} Ansvarlig for besøg: {ansvarlig}", 1);
                        Console.Clear();
                        Console.WriteLine("Din ankomst er registreret.\nFra Firma: {0}\nAnsvarlig for besøg: {1}\n\nTryk enter for at gå tilbage.", firma, ansvarlig);
                        Console.ReadLine();
                        break;
                    case "2": // Gæst melder afgang
                        Console.Clear();
                        string gæster = guesttillog.guest("", 0);
                        List<string> gæsteliste = gæster.Split(new char[] { ',' }).ToList();
                        counter = 1;
                        if (gæsteliste[0] == "")
                        {
                            Console.WriteLine("Der er pt ingen gæster der kan melde sin afgang...\n\n(Tryk enter for at gå tilbage)");
                            Console.Read();
                            break;
                        }
                        Console.WriteLine("Meld afgang - Vælg dit navn\n");
                        foreach (var l in gæsteliste)
                        {
                            Console.WriteLine($"{counter}. {l}");
                            counter++;
                        }
                        Console.WriteLine("\n(Tryk enter for at gå tilbage)");
                        try
                        {
                            int valgafgæst = int.Parse(Console.ReadLine());
                            string gæsten = gæsteliste[valgafgæst - 1];
                            Console.Clear();
                            Console.WriteLine($"Du har valgt: {gæsten}\n\nBekræft med (y/n)");
                            valg1 = Console.ReadLine();
                            switch (valg1)
                            {
                                case "y":
                                    guesttillog.guest(gæsten, 2);
                                    Console.Clear();
                                    Console.WriteLine($"Din afgang for: {gæsten} er blevet registreret.");
                                    Thread.Sleep(1500);
                                    Main();
                                    break;
                                default:
                                    break;
                            }
                        }
                        catch (FormatException)
                        {
                            break;
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            break;
                        }
                        break;
                    default: // Trykker enter for at gå tilbage
                        Main();
                        break;
                }
            }
        }
    }

}

