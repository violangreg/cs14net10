using Exercise_PrimeFactorsLib;

namespace Exercise_PrimeFactorsTests;

public class PrimeFactorsTests
{
    [Theory]
    [InlineData(-112, "Number -112 is out of range (1-1000)")]
    [InlineData(0, "Number 0 is out of range (1-1000)")]
    [InlineData(1, "None")]
    [InlineData(2, "2")]
    [InlineData(4, "2 x 2")]
    [InlineData(90, "5 x 3 x 3 x 2")]
    [InlineData(330, "11 x 5 x 3 x 2")]
    [InlineData(987, "47 x 7 x 3")]
    [InlineData(1111, "Number 1111 is out of range (1-1000)")]
    public void TestPrimeFactors(int number, string expected)
    {
        // Arrange + Act - call PrimeFactors method
        string actual = PrimeFactorsLib.PrimeFactors(number);
        // Assert - verify the result
        Assert.Equal(expected, actual);
    }
}

// build to run tests
