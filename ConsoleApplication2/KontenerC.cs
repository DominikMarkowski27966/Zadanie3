using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication2
{
    public class KontenerC : Kontener
    {
        private double temp;
        private Dictionary<Product, double> productsWithWeights;
        private string type;

        public KontenerC(
            double wysokosc,
            double wagaWlasna,
            double glebokosc,
            double maxLadownosc,
            string type,
            double temp)
            : base(wysokosc, wagaWlasna, glebokosc, maxLadownosc)
        {
            Nazwa = Nazwa + "-C-" + Id;
            this.temp = temp;
            this.type = type;
            productsWithWeights = new Dictionary<Product, double>();
        }

        public virtual void Zaladowanie(double nowaMasa, Product nowyProdukt)
        {
            if (!ProductsWithWeights.First().Key.Type.Equals(nowyProdukt.Type))
            {
                throw new DiffTypeException(Nazwa, Type, nowyProdukt.Type);
            }

            if (Temp < nowyProdukt.Temp)
            {
                throw new TempTooLowExcpetion(Nazwa, Temp, nowyProdukt.Name, nowyProdukt.Temp);
            }

            base.Zaladowanie(nowaMasa);

            if (ProductsWithWeights.ContainsKey(nowyProdukt))
            {
                ProductsWithWeights[nowyProdukt] += nowaMasa;
            }
            else
            {
                ProductsWithWeights.Add(nowyProdukt, nowaMasa);
            }
        }

        public void ShowListaProduktow()
        {
            foreach (var p in ProductsWithWeights)
            {
                Console.WriteLine(p.Key + " o wadze " + p.Value);
            }
        }

        public override string ToString()
        {
            return base.ToString()
                   + $"\nTemperatura: {Temp} stopni " +
                   $"\nTyp produktow: {Type} ";
        }

        public string Type
        {
            get => type;
            set => type = value;
        }

        public double Temp
        {
            get => temp;
            set => temp = value;
        }

        public Dictionary<Product, double> ProductsWithWeights
        {
            get => productsWithWeights;
            set => productsWithWeights = value;
        }
    }
}