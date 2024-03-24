using System;
using System.Collections.Generic;

namespace ConsoleApplication2
{
    public class KontenerL : Kontener, IHazardNotifier
    {
        private bool niebezpieczny;

        public KontenerL(
            double wysokosc,
            double wagaWlasna,
            double glebokosc,
            double maxLadownosc,
            bool niebezpieczny)
            : base(wysokosc, wagaWlasna, glebokosc, maxLadownosc)
        {
            this.niebezpieczny = niebezpieczny;
            this.MaxLadownosc = Niebiezpieczny ? MaxLadownosc * 0.5 : MaxLadownosc * 0.9;
            Nazwa = Nazwa + "-L-" + Id;
        }

        public override void Zaladowanie(double masa)
        {
            try
            {
                base.Zaladowanie(masa);
            }
            catch (OverfillException)
            {
                Info(Nazwa);
            }
        }

        public override string ToString()
        {
            string czy = niebezpieczny ? "niebezpieczny" : "bezpieczny";
            return base.ToString() + $"\nLadunek jest: {czy}";
        }

        public void Info(string idKontenera)
        {
            Console.WriteLine("Wystapil niebezpieczny incydent w kontenerze: " + idKontenera);
        }

        public bool Niebiezpieczny
        {
            get => niebezpieczny;
            set => niebezpieczny = value;
        }
    }
}