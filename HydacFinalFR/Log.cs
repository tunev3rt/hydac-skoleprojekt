using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HydacFinalFR
{

    public class Log
    {
        string dato = DateTime.Now.ToString("dd.MM.yyyy");


        public void gæstelog(string logbesked)
        {

            FileInfo fileInfo = new FileInfo($"{Environment.CurrentDirectory}/" + dato + ".txt");
            string fileName = $"{Environment.CurrentDirectory}/" + dato + ".txt";
            File.AppendAllText(fileName, DateTime.Now.ToString("HH:mm:ss ") + logbesked + Environment.NewLine);
        }
        public void Tjeklogfindes()
		{
            FileInfo fileInfo = new FileInfo($"{Environment.CurrentDirectory}/" + dato + ".txt");
            string fileName = $"{Environment.CurrentDirectory}/" + dato + ".txt";
            bool exists = fileInfo.Exists;
            if (exists == false)
                using (FileStream fs = File.Create(fileName)) ;
        }
	}
}

