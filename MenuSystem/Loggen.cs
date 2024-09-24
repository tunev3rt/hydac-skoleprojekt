using System;
using System.IO;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hydac
{
    public class Loggen
    {
        public bool loggen(string input, int valg) // Tager et medarbejder navn og et tal som argument og returnere en bool
		{
            bool erankommet = false;
            DateTime dateAndTime = DateTime.Now;
            string dato = dateAndTime.ToString("dd.MM.yyyy");
            FileInfo fileInfo = new FileInfo($"{Environment.CurrentDirectory}/" + dato + ".txt");
            string fileName = $"{Environment.CurrentDirectory}/" + dato + ".txt";
            bool exists = fileInfo.Exists;
            if (exists == false)
                using (FileStream fs = File.Create(fileName)) ;
            string afgang = "";
            string ankommedarbejd = "";
            var ankommedarbejdliste = new List<string>();
            var afgangliste = new List<string>();
            string pattern2 = @"Medarbejder: ([A-Za-z]+ [A-Za-z]+) er";
            string pattern3 = @" \s*([^:]+?)\s*har meldt";
            foreach (var line in File.ReadLines(fileName))
            {
                Match match2 = Regex.Match(line, pattern2);
                if (match2.Success)
                {
                    ankommedarbejd = match2.Groups[1].Value.Trim();
                    ankommedarbejdliste.Add(ankommedarbejd.ToString());
                }
                Match match3 = Regex.Match(line, pattern3);
                if (match3.Success)
                {
                    afgang = match3.Groups[1].Value.Trim();
                    afgangliste.Add(afgang.ToString());
                }
            }
            var medarbejderliste = ankommedarbejdliste.Except(afgangliste).ToList();

            if (valg == 0) // Checker kun om medarbejderen er clocket ind eller ud
            {
                foreach (string line in medarbejderliste)
                {
                    if (line == input)
                    {
                        erankommet = true;
                        return erankommet;
                    }
                }
                return erankommet;
            }
            else if (valg == 1) // Udfører en clock ind eller ud handling
            {
                bool ankommet = false;
                foreach (string line in medarbejderliste)
                {
                    if (line == input)
                    {
                        erankommet = false;
                        File.AppendAllText(fileName, DateTime.Now.ToString("HH:mm:ss ") + input + " har meldt sin afgang." + Environment.NewLine);
                        ankommet = true;
                        return erankommet;
                    }
                }
                if (ankommet == false)
                {
                    erankommet = true;
                    File.AppendAllText(fileName, DateTime.Now.ToString("HH:mm:ss ") + "Medarbejder: " + input + " er mødt ind." + Environment.NewLine);
                }
                return erankommet;
            }
            return erankommet;
        }
        public string hentloggen() // Funktionen der henter loggen når den skal ses
        {
            DateTime dateAndTime = DateTime.Now;
            string dato = dateAndTime.ToString("dd.MM.yyyy");
            string fileName = $"{Environment.CurrentDirectory}/" + dato + ".txt";
            FileInfo fileInfo = new FileInfo($"{Environment.CurrentDirectory}/" + dato + ".txt");
            string loggen = "";
            bool exists = fileInfo.Exists;
            if (exists == false)
                using (FileStream fs = File.Create(fileName)) ;
            Console.Clear();
            using (FileStream fs = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);

                if (fs.Read(b, 0, b.Length) > 0)
                {
                    loggen = "Loggen for dato: " + dato + "\n\n" + temp.GetString(b) + "\n\nTryk enter for at gå tilbage.";
                    return loggen;
                }
                else
                {
                    loggen = "Loggen for dato: " + dato + "\n\nLOGGEN ER TOM.\n\nTryk enter for at gå tilbage.";
                    return loggen;
                }
            }
        }
        public string guest(string input, int valg) // Tager et navn/information og et tal som argument
        {
            
            //Variabler til gæster
            string ankommede = "";
            string afgang = "";
            var ankommedeliste = new List<string>();
            var afgangliste = new List<string>();
            string gæstelistestring = "";
            string pattern = @"Navn: \s*([^:]+?)\s*fra firma";
            string pattern3 = @" \s*([^:]+?)\s*har meldt";
            DateTime dateAndTime = DateTime.Now;
            string dato = dateAndTime.ToString("dd.MM.yyyy");
            string fileName = $"{Environment.CurrentDirectory}/" + dato + ".txt";
            FileInfo fileInfo = new FileInfo($"{Environment.CurrentDirectory}/" + dato + ".txt");
            bool exists = fileInfo.Exists;
            if (exists == false)
                using (FileStream fs = File.Create(fileName)) ;

            foreach (var line in File.ReadLines(fileName)) // Laver listen over gæster der har meldt sin ankomst
            {
                Match match = Regex.Match(line, pattern);
                if (match.Success)
                {
                    ankommede = match.Groups[1].Value.Trim();
                    ankommedeliste.Add(ankommede.ToString());
                }
                Match match3 = Regex.Match(line, pattern3);
                if (match3.Success)
                {
                    afgang = match3.Groups[1].Value.Trim();
                    afgangliste.Add(afgang.ToString());
                }
            }
            var gæsteliste = ankommedeliste.Except(afgangliste).ToList();

            if (valg == 0) // Returnere listen over ankommede personer
            {
                gæstelistestring = string.Join(",", gæsteliste.ToArray());
                return gæstelistestring;
            }
            if (valg == 1) // Gemmer gæste ankomst til loggen
            {
                File.AppendAllText(fileName, DateTime.Now.ToString("HH:mm:ss ") + input + Environment.NewLine);
            }
            if (valg == 2) // Gemmer gæste afgang til loggen
            {
                File.AppendAllText(fileName, DateTime.Now.ToString("HH:mm:ss ") + input + " har meldt sin afgang." + Environment.NewLine);
            }
            return gæstelistestring;
        }
    }
}

