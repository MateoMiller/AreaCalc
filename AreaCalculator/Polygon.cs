using System.Drawing;

namespace AreaCalculator;

public class Polygon : IShape
{
    private readonly List<Point> points;

    public Polygon(List<Point> polygonPoints)
    {
        if (polygonPoints.Count < 3)
            throw new ArgumentException("A polygon must have at least 3 points");
        
        points = polygonPoints;
    }

    public double CalculateArea()
    {
        //Формула площади Гаусса
        //https://ru.wikipedia.org/wiki/%D0%A4%D0%BE%D1%80%D0%BC%D1%83%D0%BB%D0%B0_%D0%BF%D0%BB%D0%BE%D1%89%D0%B0%D0%B4%D0%B8_%D0%93%D0%B0%D1%83%D1%81%D1%81%D0%B0
        var area = 0d;

        for (var currentPoint = 0; currentPoint < points.Count; currentPoint++)
        {
            var nextPoint = (currentPoint + 1) % points.Count;
            area += points[currentPoint].X * points[nextPoint].Y - points[nextPoint].X * points[currentPoint].Y;
        }

        return Math.Abs(area) / 2;
    }
}