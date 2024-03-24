using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication2
{
    public class Statek
    {
        private string nazwa;
        private List<Kontener> kontynery;
        private double maxUdzwig;
        private double speedInKnots;
        private double aktualnaMasaTowarow;

        public Statek(string nazwa,
            double maxUdzwig,
            double speedInKnots)
        {
            this.nazwa = nazwa;
            kontynery = new List<Kontener>();
            this.maxUdzwig = maxUdzwig;
            this.speedInKnots = speedInKnots;
        }

        public void PutContanair(Kontener kontener)
        {
            double tmp = aktualnaMasaTowarow + kontener.MasaLadunku + kontener.WagaWlasna;
            if (tmp > maxUdzwig)
            {
                Console.WriteLine(
                    $"Przekroczona max mase na statku {Nazwa}, dodanie kontenera {kontener.Nazwa} nie powiodło sie");
                
            }
            else if (!Kontynery.Contains(kontener))
            {
                Console.WriteLine($"Na statek {Nazwa} dodano kontener {kontener.Nazwa}");
                Kontynery.Add(kontener);
                aktualnaMasaTowarow += kontener.MasaLadunku + kontener.WagaWlasna;
                
            }
            else
            {
                Console.WriteLine($"Na statku {Nazwa} jest juz kontener {kontener.Nazwa}");
                
            }
        }

        public void PutContanair(List<Kontener> listK)
        {
            foreach (var kontener in listK)
            {
                if (Kontynery.Contains(kontener))
                {
                    Console.WriteLine($"Statke {Nazwa} zawiera juz {kontener.Nazwa}");
                }
                else
                {
                    this.PutContanair(kontener);
                }
            }
        }

        public void TakeContanair(Kontener kontener)
        {
            if (Kontynery.Contains(kontener))
            {
                Console.WriteLine($"Z statku {Nazwa} usunieto kontner {kontener.Nazwa}");
                Kontynery.Remove(kontener);
                aktualnaMasaTowarow -= kontener.MasaLadunku + kontener.WagaWlasna;
                
            }
            else
            {
                Console.WriteLine($"Statek {Nazwa} nie posiada kontenera {kontener.Nazwa}");
                
            }
        }

        public static void ReplaceContanair(Statek statek1, Statek statek2,
            Kontener kontener1, Kontener kontener2)
        {
         
            if (statek1.Kontynery.Contains(kontener1) && statek2.Kontynery.Contains(kontener2))
            {
                
                statek1.TakeContanair(kontener1);
                statek2.TakeContanair(kontener2);
                statek1.PutContanair(kontener2);
                statek2.PutContanair(kontener1);
                Console.WriteLine($"Zamienono {kontener1.Nazwa} i {kontener2.Nazwa}");
            }
            else
            {
               Console.WriteLine($"Operacja zamiany {kontener1.Nazwa} i {kontener2.Nazwa} nie powiodla sie ");
            }
        }

        public static void MoveContanair(Statek statek1, Statek statek2, Kontener kontener)
        {
            if (statek1.Kontynery.Contains(kontener))
            {
                statek1.TakeContanair(kontener);
                statek2.PutContanair(kontener);
                Console.WriteLine($"Kontener {kontener.Nazwa} przniesiono z {statek1.Nazwa} na {statek2.Nazwa}");
            }
            else
            {
                Console.WriteLine($"Brak kontenra {kontener.Nazwa} na statku {statek1.Nazwa}");
            }
        }

        public void PokazLadunek()
        {
            foreach (var k in Kontynery)
            {
                Console.WriteLine(k);
            }
        }

        public void InfoOLadunku()
        {
            Console.WriteLine($"Statek {Nazwa} posiada {kontynery.Count} kontenery o wadze {AktualnaMasaTowaru}, a jego limit to {MaxUdzwig}");
        }

        public override string ToString()
        {
            return $"{Nazwa} ( speed={SpeedInKnots}, maxContainerNum= maxWeight={MaxUdzwig}";
        }

        public string Nazwa
        {
            get => nazwa;
            set => nazwa = value;
        }

        public List<Kontener> Kontynery
        {
            get => kontynery;
            set => kontynery = value;
        }

        public double MaxUdzwig
        {
            get => maxUdzwig;
            set => maxUdzwig = value;
        }

        public double SpeedInKnots
        {
            get => speedInKnots;
            set => speedInKnots = value;
        }

        public double AktualnaMasaTowaru
        {
            get => aktualnaMasaTowarow;
            set => aktualnaMasaTowarow = value;
        }
    }
}