namespace AreaCalculator;

public class Circle : IShape
{
    private double Radius { get; set; }
    
    public Circle(double radius)
    {
        if (radius <= 0)
            throw new ArgumentOutOfRangeException(nameof(radius), "must be positive");
        Radius = radius;
    }

    public double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}