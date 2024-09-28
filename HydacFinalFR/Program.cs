namespace HydacFinalFR;

class Program
{
    static void Main(string[] args)
    {
        // Variabler
        bool hovedmenu = true;
        int valgafmenu;
        // Initialiseringer
        Login medarbejderlogin = new Login();
        Postlogingæst gæstemenu = new Postlogingæst();
        Log tjekfil = new Log();


        tjekfil.Tjeklogfindes();
        while (hovedmenu == true)
        {
            Console.Clear();
            Console.WriteLine("Vælg om du er en gæst eller medarbejder\n\n1. Medarbejder\n2. Gæst");
            try
            {
                valgafmenu = int.Parse(Console.ReadLine());
                switch (valgafmenu)
                {
                    case 1:
                        medarbejderlogin.Medarbejdermenulogin();
                        break;
                    case 2:
                        gæstemenu.Gæstemenu();
                        break;
                    default:
                        break;
                }
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("Vælg et korrekt tal.");
                Thread.Sleep(2000);
            }
        }
    }
}

