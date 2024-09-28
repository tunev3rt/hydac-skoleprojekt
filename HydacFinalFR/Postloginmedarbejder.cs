using System;
namespace HydacFinalFR
{
	public class Postloginmedarbejder
	{
        // Variabler
        private bool postloginmenu = true;
        private int valgafmenu;

        public void Medarbejdermenu(string medarbejdernavn)
        {
            // Variabler
            postloginmenu = true;

            while (postloginmenu == true)
            {
                Console.Clear();
                Console.WriteLine($"Velkommen: {medarbejdernavn} - Vælg hvad du vil\n\n1. Clock ind/ud\n2. Registrer pause\n3. Se loggen\n4. Log af");
                try
                {
                    valgafmenu = int.Parse(Console.ReadLine());
                    switch (valgafmenu)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            postloginmenu = false;
                            break;
                        default:
                            break;
                    }
                }
                catch (FormatException)
                {
                }
            }
        }
	}
}

