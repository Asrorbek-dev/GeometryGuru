using System;

// === ABSTRACT SHAPE CLASS ===
abstract class Shape
{
    public abstract double CalculateArea();
}

// === CIRCLE CLASS ===
class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}

// === RECTANGLE CLASS ===
class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public override double CalculateArea()
    {
        return Width * Height;
    }
}

// === TRIANGLE CLASS ===
class Triangle : Shape
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }

    public Triangle(double a, double b, double c)
    {
        A = a; B = b; C = c;
    }

    public override double CalculateArea()
    {
        double s = (A + B + C) / 2;
        double temp = s * (s - A) * (s - B) * (s - C);

        if (temp < 0)
            throw new Exception("Bu tomonlar bilan uchburchak bolmaydi!");

        return Math.Sqrt(temp);
    }
}
// === TRIANGLE HELPER (3-tomon oraliq) ===
static class TriangleHelper
{
    public static void ThirdSideRange(double a, double b)
    {
        double minC = Math.Abs(a - b);
        double maxC = a + b;

        Console.WriteLine($"Uchinchi tomon C quyidagi oraliqda bolishi mumkin:");
        Console.WriteLine($"{minC} < C < {maxC}");
    }
}

// === MENU CLASS ===
class Menu
{
    public void Show()
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("=====================");
            Console.WriteLine("=== Geometry Guru ===");
            Console.WriteLine("=====================");
            Console.ResetColor();
            Console.WriteLine("1. Doira yuzasi");
            Console.WriteLine("2. Tortburchak yuzasi");
            Console.WriteLine("3. Uchburchak yuzasi");
            Console.WriteLine("4. 2 tomon berilganda 3-tomon oraliq");
            Console.WriteLine("0. Chiqish");
            Console.Write("Tanlang: ");

            string tanlov = Console.ReadLine();

            switch (tanlov)
            {
                case "1":
                    CalcCircle();
                    break;

                case "2":
                    CalcRectangle();
                    break;

                case "3":
                    CalcTriangle();
                    break;

                case "4":
                    CalcThirdSideRange();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Xato tanlov!");
                    break;
            }

            Console.WriteLine("\nDavom ettirish uchun ENTER bosing...");
            Console.ReadLine();
        }
    }

    private void CalcCircle()
    {
        Console.Write("Radius: ");
        double r = Convert.ToDouble(Console.ReadLine());
        Shape circle = new Circle(r);
        Console.WriteLine($"Doira yuzasi = {circle.CalculateArea():F2}");
    }

    private void CalcRectangle()
    {
        Console.Write("Eni: ");
        double w = Convert.ToDouble(Console.ReadLine());
        Console.Write("Boyi: ");
        double h = Convert.ToDouble(Console.ReadLine());
        Shape rect = new Rectangle(w, h);
        Console.WriteLine($"Tortburchak yuzasi = {rect.CalculateArea():F2}");
    }

    private void CalcTriangle()
    {
        Console.Write("A: ");
        double a = Convert.ToDouble(Console.ReadLine());
        Console.Write("B: ");
        double b = Convert.ToDouble(Console.ReadLine());
        Console.Write("C: ");
        double c = Convert.ToDouble(Console.ReadLine());
        try
        {
            Shape tri = new Triangle(a, b, c);
            Console.WriteLine($"Uchburchak yuzasi = {tri.CalculateArea()}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    private void CalcThirdSideRange()
    {
        Console.Write("A: ");
        double A = Convert.ToDouble(Console.ReadLine());
        Console.Write("B: ");
        double B = Convert.ToDouble(Console.ReadLine());

        TriangleHelper.ThirdSideRange(A, B);
    }
}

// === PROGRAM START ===
class Program
{
    static void Main()
    {
        Menu menu = new Menu();
        menu.Show();
    }
}