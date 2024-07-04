using System.Drawing;
using AreaCalculator;
using FluentAssertions;

namespace UnitTests.ShapesTests
{
    public class PolygonTests
    {
        [TestCaseSource(nameof(CalcualteAreaTestCases))]
        public void Polygon_CalculateArea_ReturnsCorrectAreaFor(List<Point> points, double expectedArea)
        {
            var triangle = new Polygon(points);

            var actualArea = triangle.CalculateArea();

            actualArea.Should().BeApproximately(expectedArea, 0.0001);
        }

        [TestCaseSource(nameof(InvalidTestCases))]
        public void Polygon_Ctor_ThrowsExceptionWhenNotEnoughPointsProvided(List<Point> points)
        {
            var action = () => new Polygon(points);

            action.Should().Throw<Exception>();
        }

        private static IEnumerable<List<Point>> InvalidTestCases()
        {
            yield return new List<Point>();
            yield return new List<Point> { new(1, 1) };
            yield return new List<Point> { new(1, 1), new(1, 1) };
        }

        private static IEnumerable<TestCaseData> CalcualteAreaTestCases()
        {
            yield return new TestCaseData(new List<Point>
            {
                new(0, 0),
                new(3, 0),
                new(0, 4)
            }, 6).SetName("Triangle");

            yield return new TestCaseData(new List<Point>
            {
                new(0, 0),
                new(4, 0),
                new(4, 3),
                new(0, 3)
            }, 12).SetName("Rectangle");
            yield return new TestCaseData(new List<Point>
            {
                new(0, 0),
                new(3, 0),
                new(5, 2),
                new(3, 4),
                new(0, 4)
            }, 16).SetName("Convex Pentagon");
            yield return new TestCaseData(new List<Point>
            {
                new(0, 0),
                new(0, 4),
                new(2, 2),
                new(4, 4),
                new(4, 0)
            }, 12).SetName("Concave Pentagon");
        }
    }
}