using System;

namespace ConsoleApplication2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            KontenerL k1 = new KontenerL(
                10,
                10,
                10,
                10,
                false);

            Console.Write(k1);
            try
            {
                k1.Zaladowanie(11);
            }
            catch (OverfillException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}