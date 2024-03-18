using System.Collections.Generic;

namespace ConsoleApplication2
{
    public class KontenerL : Kontener
    {
        private bool niebezpiecnzy;
        private static HashSet<int> numery = new HashSet<int>();
        public KontenerL(double masaLadunku, double wysokosc, double wagaWlasna, double glebokosc, string numer, double maxLadownosc, bool niebezpieczny)
            : base(masaLadunku, wysokosc, wagaWlasna, glebokosc, numer, maxLadownosc)
        {
            this.niebezpiecnzy = niebezpieczny;
            if (niebezpiecnzy)
            {
                MaxLadownosc *= 0.5;
            }
            else
            {
                MaxLadownosc *= 0.9;
            }
        }

        public void Zaladowanie()
        {
            
        }
        
    }
}