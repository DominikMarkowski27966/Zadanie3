using System.Collections.Generic;
using static System.Console;

namespace ConsoleApplication2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Statek statek1 = new Statek("Titanic", 100, 15);
            Statek statek2 = new Statek("Bismarck", 150, 18);
            
            KontenerL kl1 = new KontenerL(10, 10, 10, 10, false);
            KontenerL kl2 = new KontenerL(15, 15, 15, 15, true);
            KontenerL kl3 = new KontenerL(20, 20, 20, 20, true);
            List<Kontener> listL = new List<Kontener> { kl1, kl2, kl3 };
            
            KontenerG kG1 = new KontenerG(10, 10, 10, 10, 1);
            KontenerG kG2 = new KontenerG(10, 10, 10, 10, 2);
            KontenerG kG3 = new KontenerG(10, 10, 10, 10, 1);
            List<Kontener> listG = new List<Kontener> { kG1, kG2, kG3 };
            
            Product bananas = new Product("bananas", "fruit", 18);
            Product apples = new Product("apples", "fruit", 15);
            Product fish = new Product("fish", "fish", -12);
            List<Product> list = new List<Product> { bananas, apples, fish };
            
            KontenerC kC1 = new KontenerC(10, 10, 10, 10, "fruit", 15);
            KontenerC kC2 = new KontenerC(10, 10, 10, 10, "fish", -10);
            List<Kontener> listC = new List<Kontener> { kC1, kC2 };
            
            statek1.PutContanair(listL);
            statek1.PokazLadunek();
            statek2.PutContanair(listG);
            Statek.ReplaceContanair(statek1,statek2,kl1,kG2);
            WriteLine("-----------------");
            statek1.PokazLadunek();
            statek1.InfoOLadunku();

            //CLI cli = new CLI();
        }
    }
}