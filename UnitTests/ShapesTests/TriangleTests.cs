using AreaCalculator;
using FluentAssertions;

namespace UnitTests.ShapesTests;

public class TriangleTests
{
    [Test]
    public void Triangle_CalculateArea_ReturnsCorrectArea()
    {
        var triangle = new Triangle(3, 4, 5);
        var expectedArea = 6;

        var actualArea = triangle.CalculateArea();

        actualArea.Should().BeApproximately(expectedArea, 0.01);
    }

    [Test]
    public void Triangle_IsRightTriangle_ReturnsTrueForRightTriangle()
    {
        var triangle = new Triangle(3, 4, 5);

        var isRight = triangle.IsRightTriangle();

        isRight.Should().BeTrue();
    }

    [Test]
    public void Triangle_IsRightTriangle_ReturnsFalseForNonRightTriangle()
    {
        var triangle = new Triangle(3, 3, 3);

        var isRight = triangle.IsRightTriangle();

        isRight.Should().BeFalse();
    }

    [TestCase(1, 2, 10)]
    [TestCase(1, 10, 2)]
    [TestCase(10, 1, 2)]
    public void Triangle_Constructor_ThrowsExceptionForInvalidTriangleSides(double side1, double side2, double side3)
    {
        var action = () => new Triangle(side1, side2, side3);

        action.Should().Throw<Exception>();
    }

    [Test]
    public void Triangle_Constructor_ThrowsExceptionForNonPositiveSides(
        [Values(-1, 0, 1)] double side1,
        [Values(-1, 0, 1)] double side2,
        [Values(-1, 0, 1)] double side3)
    {
        if (side1 == 1 && side2 == 1 && side3 == 1)
            return;
        var action = () => new Triangle(side1, side2, side3);

        action.Should().Throw<ArgumentOutOfRangeException>();
    }
}