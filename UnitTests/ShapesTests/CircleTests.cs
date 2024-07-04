using AreaCalculator;
using FluentAssertions;

namespace UnitTests.ShapesTests
{
    public class ShapeTests
    {
        [TestCase(0)]
        [TestCase(-1)]
        public void Circle_Ctor_ThrowWhenInvalidRadius(double radius)
        {
            var action = () => new Circle(radius);
            
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void Circle_CalculateArea_ReturnsCorrectArea()
        {
            var circle = new Circle(5);
            var expectedArea = 78.54;

            var actualArea = circle.CalculateArea();

            expectedArea.Should().BeApproximately(actualArea, 0.01);
        }
    }
}