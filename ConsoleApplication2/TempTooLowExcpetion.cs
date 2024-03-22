using System;

namespace ConsoleApplication2
{
    public class TempTooLowExcpetion : Exception
    {
        public TempTooLowExcpetion(string kontener,double temp,string produkt,double tempNowy)
            : base($"Temperatura kontenera {kontener}: {temp}," +
                   $" jest nizsza niz temperatura produktu: {produkt} ktora wynosi {tempNowy}") {}
    }
}