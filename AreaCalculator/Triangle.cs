namespace AreaCalculator;

public class Triangle : IShape
{
    private double Side1 { get; set; }
    private double Side2 { get; set; }
    private double Side3 { get; set; }

    public Triangle(double side1, double side2, double side3)
    {
        ValidateCorrectSizes(side1, side2, side3);
        Side1 = side1;
        Side2 = side2;
        Side3 = side3;
    }

    public double CalculateArea()
    {
        var p = (Side1 + Side2 + Side3) / 2;
        return Math.Sqrt(p * (p - Side1) * (p - Side2) * (p - Side3));
    }

    public bool IsRightTriangle()
    {
        var sides = new[] { Side1, Side2, Side3 };
        Array.Sort(sides);
        //Тут можно сравнивать, что |a*a + b*b - c*c| < 0.0001, чтобы нивелировать ошибки округления.
        //Но я не уверен, что библиотека должна таким заниматься. Пользователь может рисовать какие-нибудь 3D модели из миллиардов треугольников
        //И там будут треугольники со стороной размера 0.00000001. А тут мы взяли и использовали погрешность больше, чем стороны самих треугольников. Это не правильно 
        return sides[0] * sides[0] + sides[1] * sides[1] == sides[2] * sides[2];
    }

    private static void ValidateCorrectSizes(double side1, double side2, double side3)
    {
        if (side1 <= 0)
            throw new ArgumentOutOfRangeException(nameof(side1), "must be positive");
        if (side2 <= 0)
            throw new ArgumentOutOfRangeException(nameof(side2), "must be positive");
        if (side3 <= 0)
            throw new ArgumentOutOfRangeException(nameof(side3), "must be positive");
        if (side1 + side2 <= side3 || 
            side1 + side3 <= side2 || 
            side2 + side3 <= side1)
            throw new Exception(
                $"Any two sides of the triangle must be larger than the other two, but found side1={side1},side2={side2},side3={side3}");
    }
}