namespace ConsoleApplication2
{
    public class Product
    {
        private string name;
        private string type;
        private double temp;

        public Product(
            string name,
            string type,
            double temp)
        {
            this.name = name;
            this.temp = temp;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public double Temp
        {
            get => temp;
            set => temp = value;
        }

        public string Type
        {
            get => type;
            set => type = value;
        }

        public override string ToString()
        {
            return $"Produkt: {Name} o typie: {Type} wymaga {temp} stopni";
        }
    }
}