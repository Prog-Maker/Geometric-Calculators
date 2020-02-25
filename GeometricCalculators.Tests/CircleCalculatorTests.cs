using NUnit.Framework;
using System;
using static GeometricCalculators.CircleCalculator;

namespace GeometricCalculators.Tests
{
    [TestFixture]
    public class CircleTests
    {
        CircleCalculator circleCalculator;

        [Test]
        [TestCase(14.5, CircleParametrType.Radius, 660.185)]
        [TestCase(20, CircleParametrType.Radius, 1256)]
        [TestCase(1, CircleParametrType.Radius, 3.14)]
        [TestCase(17.3, CircleParametrType.Radius, 939.7706)]
        [TestCase(63, CircleParametrType.Radius, 12462.66)]
        public void GetCircleAreaFromRadius(double radius,
                                            CircleParametrType parametrType,
                                            double result)
        {
            circleCalculator = new CircleCalculator(parametrType, radius: radius);

            AssertResult(result);
        }

        [Test]
        [TestCase(14.5, CircleParametrType.Diametr, 165.04625)]
        [TestCase(20, CircleParametrType.Diametr, 314)]

        public void GetCircleAreaFromDiametr(double diametr,
                                    CircleParametrType parametrType,
                                    double result)
        {
            circleCalculator = new CircleCalculator(parametrType, diametr: diametr);

            AssertResult(result);
        }

        [Test]
        [TestCase(14.5, CircleParametrType.Length, 16.73964968152866)]
        [TestCase(20, CircleParametrType.Length, 31.84713375796178)]

        public void GetCircleAreaFromLength(double length,
                            CircleParametrType parametrType,
                            double result)
        {
            circleCalculator = new CircleCalculator(parametrType, length: length);

            AssertResult(result);
        }

        [Test]
        [TestCase(0, CircleParametrType.Radius)]
        [TestCase(-1, CircleParametrType.Radius)]
        public void GetArgumentExceptionCircleAreaFromRadius(float radius,
                                   CircleParametrType parametrType)
        {
            circleCalculator = new CircleCalculator(parametrType, radius: radius);

            AssertThrows();
        }

        [Test]
        [TestCase(0, CircleParametrType.Diametr)]
        [TestCase(-1, CircleParametrType.Diametr)]
        public void GetArgumentExceptionCircleAreaFromDiametr(float diametr,
                                                           CircleParametrType parametrType)
        {
            circleCalculator = new CircleCalculator(parametrType, diametr: diametr);
            AssertThrows();
        }



        [Test]
        [TestCase(0, CircleParametrType.Length)]
        [TestCase(-1, CircleParametrType.Length)]
        public void GetArgumentExceptionCircleAreaFromLength(float length,
                                                   CircleParametrType parametrType)
        {
            circleCalculator = new CircleCalculator(parametrType, length: length);

            AssertThrows();
        }


        private void AssertResult(double result)
        {
            var res = circleCalculator.Area();

            var espsilon = Math.Abs(result - res);

            Assert.Less(espsilon, 0.001);
        }

        private void AssertThrows()
        {
            Assert.Throws<ArgumentException>(() => circleCalculator.Area());
        }
    }
}