using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Prag
{
    class Filhantering
    {
        public static string[] GetStrings(string path)
        {
            string rad;
            string[] text;
            try
            {
                using StreamReader sr = new StreamReader(path);
                rad = sr.ReadToEnd();
                text = rad.Replace("\r", "").Split('\n');
                return text;
            }
            catch (Exception)
            {
                Console.WriteLine("Kunde inte läsa filen eller något liknande: " + path);
            }
            string[] fel = new string[1];
            return fel;
        }
    }
}
