using NUnit.Framework;
using System;
using static GeometricCalculators.TriangleCalculator;

namespace GeometricCalculators.Tests
{
    [TestFixture]
    public class TriangleCalculatorTests
    {
        TriangleCalculator calculator;

        [Test]
        [TestCase(CalcAreaType.TreeSide, 10, 10, 21)]
        [TestCase(CalcAreaType.TreeSide, 5, 5, 11)]
        [TestCase(CalcAreaType.TreeSide, 7, 8, 16)]
        public void GetArgumentExceptionFromGetAreaFromTreeSides(CalcAreaType calcType,
                                                                        double a_Side,
                                                                        double b_Side,
                                                                        double c_Side)
        {
            calculator = new TriangleCalculator(calcType, a_Side: a_Side,
                                                          b_Side: b_Side,
                                                           c_Side: c_Side);

            Assert.Throws<ArgumentException>(() => calculator.Area());
        }

        [Test]
        [TestCase(CalcAreaType.TwoSidesAndAngleBetweenThem, 10, 10, 180)]
        [TestCase(CalcAreaType.TwoSidesAndAngleBetweenThem, 5, 5, 360)]
        [TestCase(CalcAreaType.TwoSidesAndAngleBetweenThem, 7, 8, 210)]
        public void GetArgumentExceptionFromWrongAngle(CalcAreaType calcType,
                                                                double a_Side,
                                                                double b_Side,
                                                                double angle)
        {
            calculator = new TriangleCalculator(calcType, a_Side: a_Side,
                                                          b_Side: b_Side,
                                                           angle: angle);

            Assert.Throws<ArgumentException>(() => calculator.Area());
        }

        [Test]
        [TestCase(CalcAreaType.TwoSidesAndAngleBetweenThem, 0, 0, 0)]
        public void GetArgumentExceptionFromAllSidesZero(CalcAreaType calcType,
                                                        double a_Side,
                                                        double b_Side,
                                                        double c_Side)
        {
            calculator = new TriangleCalculator(calcType, a_Side: a_Side,
                                                          b_Side: b_Side,
                                                           c_Side: c_Side);

            Assert.Throws<ArgumentException>(() => calculator.Area());
        }


        [Test]
        [TestCase(CalcAreaType.TreeSide, 10, 10, 19, 29.663740492392392)]
        [TestCase(CalcAreaType.TreeSide, 5, 5, 10, 0)]
        [TestCase(CalcAreaType.TreeSide, 7, 8, 14, 18.799933510520724)]
        public void GetAreaFromTreeSides(CalcAreaType calcType,
                                                                       double a_Side,
                                                                       double b_Side,
                                                                       double c_Side,
                                                                       double result)
        {
            calculator = new TriangleCalculator(calcType, a_Side: a_Side,
                                                          b_Side: b_Side,
                                                           c_Side: c_Side);

            Assert.AreEqual(result, calculator.Area());
        }


        [Test]
        [TestCase(90, 1)]
        [TestCase(45, 0.7071067811865475)]
        [TestCase(14, 0.24192189559966773)]
        [TestCase(140, 0.6427876096865395)]
        public void GetSinus(double angle, double result)
        {
            Assert.AreEqual(result, Math.Sin(Math.PI * angle / 180));
        }

        [Test]
        [TestCase(CalcAreaType.TwoSidesAndAngleBetweenThem, 10, 5, 90, 25)]
        [TestCase(CalcAreaType.TwoSidesAndAngleBetweenThem, 5, 5, 140, 8.034849988791544)]
        [TestCase(CalcAreaType.TwoSidesAndAngleBetweenThem, 7, 8, 14, 6.7738130767906961)]
        public void GetAreaFromTwoSidesAndAngle(CalcAreaType calcType,
                                                               double first_Side,
                                                               double second_Side,
                                                               double angle,
                                                               double result)
        {
            calculator = new TriangleCalculator(calcType, a_Side: first_Side,
                                                          c_Side: second_Side,
                                                          angle: angle);

            AssertResult(result);

            calculator = new TriangleCalculator(calcType, b_Side: first_Side,
                                                          c_Side: second_Side,
                                                          angle: angle);

            AssertResult(result);

            calculator = new TriangleCalculator(calcType, a_Side: first_Side,
                                                          b_Side: second_Side,
                                                          angle: angle);

            AssertResult(result);
        }

        [Test]
        [TestCase(10, 20, 22.360679774997898)] // 22.360679774997898
        [TestCase(20, 20, 28.284271247461902)]  
        [TestCase(14, 14, 19.79898987322333)]
        public void GetTrueIsTriangleRectangular(double a_Side, double b_Side, double c_Side)
        {
            calculator = new TriangleCalculator(CalcAreaType.TreeSide, a_Side: a_Side, 
                                                                       b_Side: b_Side, 
                                                                       c_Side: c_Side);

            Assert.True(calculator.IsTriangleRectangular);
        }

        [Test]
        [TestCase(10, 20, 22)] // 22.360679774997898
        [TestCase(20, 20, 27.284271247461902)]
        [TestCase(14, 14, 14)]
        public void GetFalseIsTriangleRectangular(double a_Side, double b_Side, double c_Side)
        {
            calculator = new TriangleCalculator(CalcAreaType.TreeSide, a_Side: a_Side,
                                                                       b_Side: b_Side,
                                                                       c_Side: c_Side);

            Assert.False(calculator.IsTriangleRectangular);
        }

        private void AssertResult(double result)
        {
            var res = calculator.Area();

            var espsilon = Math.Abs(result - res);

            Assert.Less(espsilon, 0.001);
        }
    }
}
