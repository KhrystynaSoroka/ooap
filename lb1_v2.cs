using System;
abstract class Shape
{
    public Shape()
    {
        Console.WriteLine("Об'єкт створено");
    }
    public abstract double Area();
    public void ShowArea()
    {
        Console.WriteLine($"{Name()}: площа = {Area():F2}");
    }
    public abstract string Name();
}

class Square : Shape
{
    private double side;
    public Square(double side)
    {
        this.side = side;
    }
    public override double Area() { 
        return side * side; }
    public override string Name() { 
        return "Квадрат"; }
}

class Rectangle : Shape
{
    private double width;
    private double height;
    public Rectangle(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    public override double Area() { 
        return width * height; }
    public override string Name() { 
        return "Прямокутник"; }
}

class Circle : Shape
{
    private double radius;
    public Circle(double radius)
    {
        this.radius = radius;
    }
    public override double Area() { 
        return Math.PI * radius * radius; }
    public override string Name() { 
        return "Круг"; }
}

class Program
{
    static void Main()
    {
        Shape square = new Square(4);
        square.ShowArea();
        Shape rectangle = new Rectangle(3, 5);
        rectangle.ShowArea();
        Shape circle = new Circle(2);
        circle.ShowArea();

        Console.ReadKey();
    }
}
