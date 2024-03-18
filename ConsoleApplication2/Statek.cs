using System.Collections.Generic;

namespace ConsoleApplication2
{
    public class Statek
    {
        private string nazwa;
        private List<Kontener> kontynery;

        public Statek(string nazwa, List<Kontener> kontynery)
        {
            this.nazwa = nazwa;
            this.kontynery = kontynery;
            
        }
    }
}