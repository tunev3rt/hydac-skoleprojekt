using System;
namespace HydacFinalFR
{
	public class Login
	{
        private int medarbejderid;
		private bool loginmenu = true;
        private string medarbejdernavn = "";

		public void Medarbejdermenulogin()
		{
            //Initialiseringer
            Postloginmedarbejder medarbejdermenu = new Postloginmedarbejder();

            loginmenu = true;
			while (loginmenu == true)
			{
                Console.Clear();
                Console.WriteLine("Medarbejder login\n\nIndtast dit medarbejder ID...\n\n(Tast 0 for at gå tilbage)");
				try
				{
					medarbejderid = int.Parse(Console.ReadLine());
					if (medarbejderid == 0)
					{
						loginmenu = false;
					}
					else
					{
                        medarbejdernavn = Medarbejderlogin(medarbejderid);
                        if (medarbejdernavn == "")
                        {
                            Console.Clear();
                            Console.WriteLine("Ugyldigt id, prøv igen...");
                            Thread.Sleep(2000);
                        }
						else
						{
							medarbejdermenu.Medarbejdermenu(medarbejdernavn);
							loginmenu = false;
						}
                    }
				}
				catch (FormatException)
				{
					Console.Clear();
					Console.WriteLine("Ugyldigt id, prøv igen...");
					Thread.Sleep(2000);
				}
            }
		}
		private string Medarbejderlogin(int medarbejderid)
		{
			switch (medarbejderid)
			{
				case 123:
					medarbejdernavn = "John Johnson";
					break;
				case 321:
					medarbejdernavn = "Peter Petersen";
					break;
				case 222:
					medarbejdernavn = "Lars Larsen";
					break;
				default:
					medarbejdernavn = "";
					break;
			}
			return medarbejdernavn;
		}
	}
}

