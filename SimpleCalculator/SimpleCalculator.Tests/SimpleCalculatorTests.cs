using System;
using Xunit;
using SimpleCalculator;

namespace SimpleCalculator.Tests
{
    public class SimpleCalculatorTests
    {
        [Fact]
        public void Constructor()
        {
            //Arrange
            decimal num1 = 26.86m;
            decimal num2 = 3.867m;
            decimal num3 = -10;
            decimal num4 = 20.2m;
            decimal num5 = 25;

            decimal[] numsArray1 = {23.45m, 6, 9, 0.316m, -10, 7, -6};
            decimal[] numsArray2 = {1, 6, -10, 8, 9.8m};
            decimal[] numsArray3 = {100, 6, 10, 8, 9.8m};
            decimal[] numsArray4 = {100, 6, 10, 8, 0};
            
            //Act
            decimal twoNumsAddition = Program.Addition(num1, num2);

            decimal twoNumsSubtraction = Program.Subtraction(num1, num3);

            decimal arrayAddition = Program.Addition(numsArray1);

            decimal arraySubtraction = Program.Subtraction(numsArray2);

            decimal arrayMultiplication = Program.Multiplication(numsArray2);

            decimal arrayDivision = Program.Division(numsArray3);

            double squareRoot = Program.SquareRoot((double)num5);

            double raiseToPower = Program.RaiseToPower((double)num1, (double)num2);

            double circleCircumference = Program.CircleCircumference((double)num4);

            double circleArea = Program.CircleArea((double)num4);

            double sphereVolume = Program.SpereVolume((double)num4);

            //Assert
            Assert.Equal(30.727m, twoNumsAddition, 3);
            Assert.Equal(30.73m, twoNumsAddition, 2);
            Assert.Equal(29.766m, arrayAddition, 3);

            Assert.Equal(36.86m, twoNumsSubtraction);
            Assert.Equal(-12.8m, arraySubtraction);

            Assert.Equal(-4704, arrayMultiplication);

            Assert.Equal(0.021m, arrayDivision, 3);
            Assert.Throws<DivideByZeroException>(() => Program.Division(numsArray4));

            Assert.Equal(5, squareRoot);

            Assert.Equal(336010.57, raiseToPower, 2);

            Assert.Equal(63.460, circleCircumference, 3);

            Assert.Equal(320.47, circleArea, 2);

            Assert.Equal(4315.715, sphereVolume, 3);
        }
    }
}
