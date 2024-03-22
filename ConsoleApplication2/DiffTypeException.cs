using System;

namespace ConsoleApplication2
{
    public class DiffTypeException : Exception
    {
        public DiffTypeException(string kontener,string type1,string type2)
            : base(
                $"Do kontenera: {kontener} Mozna ladowac tylko produkty o typie {type1}, a nie {type2}")
        {
        }
    }
}