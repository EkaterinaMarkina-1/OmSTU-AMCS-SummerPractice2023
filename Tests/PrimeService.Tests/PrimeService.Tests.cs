using Xunit;
using SquareEquationLib;

namespace SquareEquation_Test
{
    public class SquareEquation_Test
    {

    [Theory]
    [InlineData(double.NaN,1,1)]
    [InlineData(1,double.NaN,1)]
    [InlineData(1,1,double.NaN)]

    [InlineData(double.PositiveInfinity, 2, 3)]
    [InlineData(2, double.PositiveInfinity, 3)]
    [InlineData(2, 3, double.PositiveInfinity)]

     [InlineData(double.NegativeInfinity, 2, 3)]
     [InlineData(2, double.NegativeInfinity, 3)]
     [InlineData(2, 3, double.NegativeInfinity)]
    public void Solve_ThrowsArgumentException(double a,double b, double c)
    {
        Assert.Throws<ArgumentException>(() => SquareEquation.Solve(a, b, c));
    }

    [Theory]
        [InlineData(1, -3, 2, new double[] { 1, 2 })]
        [InlineData(2, -7, 3, new double[] { 1, 1.5 })]
        [InlineData(1, -2, 1, new double[] { 1 })]
        [InlineData(1, 0, -1, new double[] { 1, -1 })]

        public void  Solve_ReturnsCorrectRoots(double a, double b, double c, double[] expected)
        {
            
        double[] actual = SquareEquation.Solve(a, b, c);


            Array.Sort(actual);
            Array.Sort(expected);

            if (expected.Length != actual.Length)
            {
                Assert.Fail("The number of roots does not match the expected result.");
            }

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i], actual[i], 6);
            }
        }
    }
}