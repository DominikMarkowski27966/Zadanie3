namespace ConsoleApplication2
{
    public abstract class Kontener
    {
        private double masaLadunku;
        private double wysokosc;
        private double wagaWlasna;
        private double glebokosc;
        private string numer;
        private double maxLadownosc;
        
        protected Kontener(double masaLadunku, double wysokosc, double wagaWlasna, double glebokosc, string numer,
            double maxLadownosc)
        {
            
            this.masaLadunku = masaLadunku;
            this.wysokosc = wysokosc;
            this.wagaWlasna = wagaWlasna;
            this.glebokosc = glebokosc;
            this.numer = "KON-"+numer;
            this.maxLadownosc = maxLadownosc;
            
        }
        
        protected void Oproznienie()
        {
            masaLadunku = 0;
        }
        protected void Zaladowanie(double nowaMasa)
        {
            nowaMasa += masaLadunku;
            if (nowaMasa > maxLadownosc)
            {
                throw new OverfillException("Przekroczony max mase");
            }
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

        public string Numer
        {
            get => numer;
            set => numer = value;
        }

        public double MaxLadownosc
        {
            get => maxLadownosc;
            set => maxLadownosc = value;
        }
    }
}
