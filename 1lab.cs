using System;
using System.Collections.Generic;

class Baggage
{
    public string TagId;
    public double Weight;

    public Baggage(string tagId, double weight)
    {
        TagId = tagId;
        Weight = weight;
    }

    public string Info()
    {
        return "номер " + TagId + ", " + Weight + " кг";
    }
}

class Passenger
{
    public string Name;
    public Baggage Baggage;

    public Passenger(string name, Baggage baggage)
    {
        Name = name;
        Baggage = baggage;
    }

    public string Info()
    {
        if (Baggage == null)
            return Name + ": багажу немає";
        return Name + ": " + Baggage.Info();   // делегування
    }
}

class BaggageDepartment
{
    List<Passenger> passengers = new List<Passenger>();

    public void Add(Passenger p)
    {
        passengers.Add(p);
    }

    public void Report()
    {
        foreach (Passenger p in passengers)
            Console.WriteLine(p.Info());       // делегування
    }
}

class Program
{
    static void Main()
    {
        BaggageDepartment department = new BaggageDepartment();
        department.Add(new Passenger("Іван", new Baggage("1", 19.5)));
        department.Add(new Passenger("Марія", new Baggage("2", 23)));
        department.Add(new Passenger("Петро", null));
        department.Report();
    }
}