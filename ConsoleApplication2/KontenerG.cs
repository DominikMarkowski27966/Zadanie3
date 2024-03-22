using System;

namespace ConsoleApplication2
{
    public class KontenerG : Kontener, IHazardNotifier
    {
        private int atmosfera;

        public KontenerG(
            double wysokosc,
            double wagaWlasna,
            double glebokosc,
            double maxLadownosc,
            int atmosfera)
            : base(wysokosc, wagaWlasna, glebokosc, maxLadownosc)
        {
            Nazwa = Nazwa + "-G-" + Id;
            this.atmosfera = atmosfera;
        }

        public override void Oproznienie()
        {
            MasaLadunku -= MasaLadunku * 0.95;
        }

        public override void Zaladowanie(double nowaMasa)
        {
            try
            {
                base.Zaladowanie(nowaMasa);
            }
            catch (OverfillException e)
            {
                Info(Nazwa);
                Console.WriteLine(e);
            }
        }

        public override string ToString()
        {
            return base.ToString() +
                   $"Atmosfery: {Atmosfera}";
        }

        public int Atmosfera
        {
            get => atmosfera;
            set => Atmosfera = value;
        }

        public void Info(string idKontenera)
        {
            Console.WriteLine("Wystapil niebezpieczny incydent w kontenerze: " + idKontenera);
        }
    }
}