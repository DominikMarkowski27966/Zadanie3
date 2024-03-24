using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

namespace ConsoleApplication2
{
    public abstract class Kontener
    {
        private double masaLadunku;
        private double wysokosc;
        private double wagaWlasna;
        private double glebokosc;
        private int id;
        private string nazwa;
        private double maxLadownosc;

        private static HashSet<int> ids = new HashSet<int>();
        private static Dictionary<int, Kontener> dictOfCon = new Dictionary<int, Kontener>();

        protected Kontener(
            double wysokosc,
            double wagaWlasna,
            double glebokosc,
            double maxLadownosc)
        {
            this.masaLadunku = 0;
            this.wysokosc = wysokosc;
            this.wagaWlasna = wagaWlasna;
            this.glebokosc = glebokosc;
            this.id = GenerujNumer(ids);
            this.nazwa = "KON";
            this.maxLadownosc = maxLadownosc;
            dictOfCon.Add(Id, this);
        }

        public virtual void Oproznienie()
        {
            MasaLadunku = 0;
        }

        public virtual void Zaladowanie(double nowaMasa)
        {
            nowaMasa += MasaLadunku;
            if (nowaMasa > MaxLadownosc)
            {
                throw new OverfillException("Przekroczony max mase");
            }

            if (nowaMasa < 0)
            {
                Console.WriteLine("Nie mozna dodawac ujemnej masy");
                return;
            }

            MasaLadunku = nowaMasa;
        }

        protected static int GenerujNumer(HashSet<int> hashSet)
        {
            for (int i = 1; i <= hashSet.Count + 1; i++)
            {
                if (!hashSet.Contains(i))
                {
                    hashSet.Add(i);
                    return i;
                }
            }

            return 0;
        }

        public override string ToString()
        {
            return $"Kontener: {Nazwa}\nLadunek: {MasaLadunku} kg" +
                   $"\nWysokosc: {Wysokosc} m " +
                   $"\nWaga {WagaWlasna} kg " +
                   $"\nGlebokosc: {Glebokosc} m " +
                   $"\nMax ladownosc: {MaxLadownosc} ";
        }

        public Kontener GetById(int kontenerId)
        {
            if (dictOfCon.TryGetValue(kontenerId, out Kontener kontener))
            {
                return kontener;
            }
            else
            {
                Console.WriteLine($"Brak kontenera o id: {kontenerId}");
            }

            return null;
        }


        public double MasaLadunku
        {
            get => masaLadunku;
            set => masaLadunku = value;
        }

        public double Wysokosc
        {
            get => wysokosc;
            set => wysokosc = value;
        }

        public double WagaWlasna
        {
            get => wagaWlasna;
            set => wagaWlasna = value;
        }

        public double Glebokosc
        {
            get => glebokosc;
            set => glebokosc = value;
        }

        public double MaxLadownosc
        {
            get => maxLadownosc;
            set => maxLadownosc = value;
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Nazwa
        {
            get => nazwa;
            set => nazwa = value;
        }

        public static Dictionary<int, Kontener> DictOfCon
        {
            get => dictOfCon;
            set => dictOfCon = value;
        }
    }
}