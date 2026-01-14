using CalculatorLib;

namespace CalculatorLibUnitTests;

public class CalculatorUnitTests
{
    [Theory]
    [InlineData(2, 2, 4)]
    [InlineData(2, 3, 5)]
    public void TestAdding(double a, double b, double expected)
    {
        // Arrange - create calculator instance
        Calculator calc = new();
        // Act - call Add method
        double actual = calc.Add(a, b);
        // Assert - verify the result
        Assert.Equal(expected, actual);
    }
}
