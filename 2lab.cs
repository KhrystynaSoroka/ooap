using System;
using System.Collections.Generic;

namespace lab
{

    public interface IGiftSetBuilder
    {
        void BuildName();
        void BuildLollipops();
        void BuildChocolates();
        void BuildWafers();
        void BuildDragee();
        void Reset();
    }

    public class LasunkaBuilder : IGiftSetBuilder
    {
        private GiftSet _product = new GiftSet();
        public LasunkaBuilder()
        {
            this.Reset();
        }
        public void Reset()
        {
            this._product = new GiftSet();
        }
        public void BuildName()
        {
            this._product.Name = "Економічний «Ласунка»";
        }
        public void BuildLollipops()
        {
            this._product.AddCandy("Льодяники", 0.450);
        }
        public void BuildChocolates()
        {
            this._product.AddCandy("Шоколадні цукерки", 0.100);
        }
        public void BuildWafers()
        {
            this._product.AddCandy("Вафлі", 0.350);
        }

        public void BuildDragee()
        {
            this._product.AddCandy("Драже", 0.100);
        }
        public GiftSet GetProduct()
        {
            GiftSet result = this._product;
            this.Reset();
            return result;
        }
    }

    public class NamynaykoBuilder : IGiftSetBuilder
    {
        private GiftSet _product = new GiftSet();
        public NamynaykoBuilder()
        {
            this.Reset();
        }
        public void Reset()
        {
            this._product = new GiftSet();
        }
        public void BuildName()
        {
            this._product.Name = "Стандартний «Наминайко»";
        }

        public void BuildLollipops()
        {
            this._product.AddCandy("Льодяники", 0.250);
        }
        public void BuildChocolates()
        {
            this._product.AddCandy("Шоколадні цукерки", 0.250);
        }
        public void BuildWafers()
        {
            this._product.AddCandy("Вафлі", 0.250);
        }
        public void BuildDragee()
        {
            this._product.AddCandy("Драже", 0.250);
        }
        public GiftSet GetProduct()
        {
            GiftSet result = this._product;
            this.Reset();
            return result;
        }
    }

    public class PanKotskyBuilder : IGiftSetBuilder
    {
        private GiftSet _product = new GiftSet();
        public PanKotskyBuilder()
        {
            this.Reset();
        }
        public void Reset()
        {
            this._product = new GiftSet();
        }

        public void BuildName()
        {
            this._product.Name = "Екстра «Пан Коцький»";
        }
        public void BuildLollipops()
        {
            this._product.AddCandy("Льодяники", 0.050);
        }
        public void BuildChocolates()
        {
            this._product.AddCandy("Шоколадні цукерки", 0.550);
        }

        public void BuildWafers()
        {
            this._product.AddCandy("Вафлі", 0.150);
        }

        public void BuildDragee()
        {
            this._product.AddCandy("Драже", 0.250);
        }

        public GiftSet GetProduct()
        {
            GiftSet result = this._product;
            this.Reset();
            return result;
        }
    }


    public class GiftSet
    {
        public string Name { get; set; } = "Без назви";
        private List<(string TypeName, double WeightKg)> _parts = new List<(string, double)>();///список для всіх сетів різних типів(складових
        public void AddCandy(string candyType, double weightKg)
        {
            this._parts.Add((candyType, weightKg));
        }
        public string GetDetails(Dictionary<string, double> pricesPerKg)
        {
            string str = $"Набір: «{Name}»\n";
            double totalWeight = 0;
            double totalPrice = 0;

            foreach (var part in _parts)
            {
                double cost = part.WeightKg * pricesPerKg[part.TypeName];
                totalWeight += part.WeightKg;
                totalPrice += cost;
                str += $" {part.TypeName}: {part.WeightKg:F3} кг ({cost:F2} грн)\n";
            }

            str += $"Загальна вага: {totalWeight:F3} кг\n";
            str += $"Загальна вартість: {totalPrice:F2} грн\n";
            return str;
        }
    }

    // Директор 
    public class PackingDirector
    {
        private IGiftSetBuilder _builder;
        public IGiftSetBuilder Builder
        {
            set { _builder = value; }
        }
        public void BuildFullSet()
        {
            this._builder.BuildName();
            this._builder.BuildLollipops();
            this._builder.BuildChocolates();
            this._builder.BuildWafers();
            this._builder.BuildDragee();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var pricesPerKg = new Dictionary<string, double>
            {
                { "Льодяники", 120.0 },
                { "Шоколадні цукерки", 350.0 },
                { "Вафлі", 150.0 },
                { "Драже", 200.0 }
            };


            var director = new PackingDirector();

            var lasunkaBuilder = new LasunkaBuilder();
            director.Builder = lasunkaBuilder;
            Console.WriteLine("Пакування набору 1:");
            director.BuildFullSet();
            Console.WriteLine(lasunkaBuilder.GetProduct().GetDetails(pricesPerKg));
            var namynaykoBuilder = new NamynaykoBuilder();
            director.Builder = namynaykoBuilder;
            Console.WriteLine("Пакування набору 2:");
            director.BuildFullSet();
            Console.WriteLine(namynaykoBuilder.GetProduct().GetDetails(pricesPerKg));
            var panKotskyBuilder = new PanKotskyBuilder();
            director.Builder = panKotskyBuilder;
            Console.WriteLine("Пакування набору 3:");
            director.BuildFullSet();
            Console.WriteLine(panKotskyBuilder.GetProduct().GetDetails(pricesPerKg));


            Console.ReadKey();
        }
    }
}
