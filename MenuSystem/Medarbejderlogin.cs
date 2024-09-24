namespace Hydac;

	public class Medarbejderlogin
	{
		public string login(string adgangskode) // Tager en adgangskode som argument og returnere navnet tilsvarende til adgangskoden
		{
		string medarbejdernavn = " ";
		if (adgangskode == "123")
		{
			medarbejdernavn = "John Johnson";
			return medarbejdernavn;
		}
		else if (adgangskode == "321")
		{
			medarbejdernavn = "Peter Petersen";
			return medarbejdernavn;
		}
		else if (adgangskode == "222")
		{
			medarbejdernavn = "Lars Larsen";
			return medarbejdernavn;
		}
		else
			return medarbejdernavn;
		}
	}

