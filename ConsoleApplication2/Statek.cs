using System.Collections.Generic;

namespace ConsoleApplication2
{
    public class Statek
    {
        private string nazwa;
        private List<Kontener> kontynery;
        private double maxUdzwig;
        private double speedInKnots;

        public Statek(string nazwa, List<Kontener> kontynery, double maxUdzwig,double speedInKnots)
        {
            this.nazwa = nazwa;
            this.kontynery = kontynery;
            this.maxUdzwig = maxUdzwig;
            this.speedInKnots = speedInKnots;
        }
    }
}