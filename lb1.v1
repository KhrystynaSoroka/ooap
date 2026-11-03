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
    public Baggage Baggage; ///ств змінної типу багаж

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
    List<Passenger> passengers = new List<Passenger>(); ///список пасажирів

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
        department.Add(new Passenger("людина 1", new Baggage("1", 19.5)));
        department.Add(new Passenger("людина 2", new Baggage("2", 23)));
        department.Add(new Passenger("людина 3", null));
        department.Report();

        Console.ReadKey();
    }
}
