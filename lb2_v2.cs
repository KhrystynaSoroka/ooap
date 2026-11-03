using System;
using System.Collections.Generic;

namespace FacadeFactory
{
    interface IFacade
    {
        double Price();
        string Info();
    }
    interface ISolidFacade : IFacade { }    
    interface IShowcaseFacade : IFacade { }  
    class FilmSolid : ISolidFacade
    {
        private double width, height;
        private const double PricePerM = 800;

        public FilmSolid(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public double Price() { 
            return width * height * PricePerM; }

        public string Info()
        {
            return $"Суцільний (плівка): {width} x {height} м, " +
                   $"площа {width * height:F2} м², ціна {Price():F2} грн";
        }
    }

    class FilmShowcase : IShowcaseFacade
    {
        private double width, height;
        private const double PricePerM = 800;
        public FilmShowcase(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
        public double Price() { return width * height * PricePerM; }
        public string Info()
        {
            return $"Вітрина (плівка): {width} x {height} м, " +
                   $"площа {width * height:F2} м², ціна {Price():F2} грн";
        }
    }

    class PaintedSolid : ISolidFacade
    {
        private double width, height;
        private const double PricePerM = 1200;
        public PaintedSolid(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
        public double Price() { return width * height * PricePerM; }
        public string Info()
        {
            return $"Суцільний (фарбований): {width} x {height} м, " +
                   $"площа {width * height:F2} м², ціна {Price():F2} грн";
        }
    }

    class PaintedShowcase : IShowcaseFacade
    {
        private double width, height;
        private const double PricePerM = 1200;
        public PaintedShowcase(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
        public double Price() { return width * height * PricePerM; }
        public string Info()
        {
            return $"Вітрина (фарбований): {width} x {height} м, " +
                   $"площа {width * height:F2} м², ціна {Price():F2} грн";
        }
    }
    class PlasticSolid : ISolidFacade
    {
        private double width, height;
        private const double PricePerM = 1000;

        public PlasticSolid(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
        public double Price() { return width * height * PricePerM; }
        public string Info()
        {
            return $"Суцільний (пластик): {width} x {height} м, " +
                   $"площа {width * height:F2} м², ціна {Price():F2} грн";
        }
    }

    class PlasticShowcase : IShowcaseFacade
    {
        private double width, height;
        private const double PricePerM = 1000;
        public PlasticShowcase(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
        public double Price() { return width * height * PricePerM; }

        public string Info()
        {
            return $"Вітрина (пластик): {width} x {height} м, " +
                   $"площа {width * height:F2} м², ціна {Price():F2} грн";
        }
    }

    // Абстрактна фабрика
    interface IFacadeFactory
    {
        ISolidFacade CreateSolid(double width, double height);
        IShowcaseFacade CreateShowcase(double width, double height);
    }

    // Конкретні фабрики
    class FilmFactory : IFacadeFactory
    {
        public ISolidFacade CreateSolid(double w, double h) { 
            return new FilmSolid(w, h); }
        public IShowcaseFacade CreateShowcase(double w, double h) { 
            return new FilmShowcase(w, h); }
    }

    class PaintedFactory : IFacadeFactory
    {
        public ISolidFacade CreateSolid(double w, double h) { 
            return new PaintedSolid(w, h); }
        public IShowcaseFacade CreateShowcase(double w, double h) { 
            return new PaintedShowcase(w, h); }
    }

    class PlasticFactory : IFacadeFactory
    {
        public ISolidFacade CreateSolid(double w, double h) { 
            return new PlasticSolid(w, h); }
        public IShowcaseFacade CreateShowcase(double w, double h) { 
            return new PlasticShowcase(w, h); }
    }

    class Order
    {
        private List<IFacade> facades = new List<IFacade>();
        public void Add(IFacade facade) { 
            facades.Add(facade); }
        public void Show()
        {
            double total = 0;
            foreach (IFacade f in facades)
            {
                Console.WriteLine(f.Info());
                total += f.Price();
            }
            Console.WriteLine($"Вартість замовлення: {total:F2} грн");
        }
    }

    class Program
    {
        static void Main()
        {
            Order order = new Order();
            IFacadeFactory factory = new PaintedFactory();
            order.Add(factory.CreateSolid(100, 50));
            order.Add(factory.CreateShowcase(111, 33));
            order.Add(factory.CreateShowcase(79, 45));
            order.Add(factory.CreateSolid(56, 40));
            order.Show();


            Console.ReadKey();
        }
    }
}
