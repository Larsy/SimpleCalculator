using System;
using Xunit;
using SimpleCalculator;

namespace SimpleCalculator.Tests
{
    public class SimpleCalculatorTests
    {
        //Arrange
        decimal num1 = 26.86m;
        decimal num2 = 3.867m;
        decimal num3 = -10;
        decimal num4 = 20.2m;
        decimal num5 = 25;

        decimal[] numsArray1 = { 23.45m, 6, 9, 0.316m, -10, 7, -6 };
        decimal[] numsArray2 = { 1, 6, -10, 8, 9.8m };
        decimal[] numsArray3 = { 100, 6, 10, 8, 9.8m };
        decimal[] numsArray4 = { 100, 6, 10, 8, 0 };
        decimal[] numsArray5 = { -12, -3, 5, 24 };

        [Fact]
        public void AdditionTests()
        {
            //Act
            decimal twoNumsAddition = Program.Addition(num1, num2);
            decimal arrayAddition = Program.Addition(numsArray1);

            //Assert
            Assert.Equal(30.727m, twoNumsAddition, 3);
            Assert.Equal(30.73m, twoNumsAddition, 2);
            Assert.Equal(29.766m, arrayAddition, 3);
        }
        [Fact]
        public void SubtractionTests()
        {
            //Act
            decimal twoNumsSubtraction = Program.Subtraction(num1, num3);
            decimal arraySubtraction = Program.Subtraction(numsArray2);
            decimal arraySubtractionUlf = Program.Subtraction(numsArray5);

            //Assert
            Assert.Equal(36.86m, twoNumsSubtraction);
            Assert.Equal(-12.8m, arraySubtraction);
            Assert.Equal(-38, arraySubtractionUlf);
        }
        [Fact]
        public void MultiplicationTests()
        {
            //Act
            decimal arrayMultiplication = Program.Multiplication(numsArray2);

            //Assert
            Assert.Equal(-4704, arrayMultiplication);
        }
        [Fact]
        public void DivisionTests()
        {
            //Act
            decimal arrayDivision = Program.Division(numsArray3);

            //Assert
            Assert.Equal(0.021m, arrayDivision, 3);
            Assert.Throws<DivideByZeroException>(() => Program.Division(numsArray4));
        }
        [Fact]
        public void SquareRootTests()
        {
            //Act
            double squareRoot = Program.SquareRoot((double)num5);

            //Assert
            Assert.Equal(5, squareRoot);
        }
        [Fact]
        public void RaiseToPowerTests()
        {
            //Act
            double raiseToPower = Program.RaiseToPower((double)num1, (double)num2);

            //Assert
            Assert.Equal(336010.57, raiseToPower, 2);
        }
        [Fact]
        public void CIrcleCircumferenceTests()
        {
            //Act
            double circleCircumference = Program.CircleCircumference((double)num4);

            //Assert
            Assert.Equal(63.460, circleCircumference, 3);
        }
        [Fact]
        public void CircleAreaTests()
        {
            //Act
            double circleArea = Program.CircleArea((double)num4);

            //Assert
            Assert.Equal(320.47, circleArea, 2);
        }
        [Fact]
        public void SphereVolumeTests()
        {
            //Act
            double sphereVolume = Program.SpereVolume((double)num4);

            //Assert
            Assert.Equal(4315.715, sphereVolume, 3);
        }
    }
}
