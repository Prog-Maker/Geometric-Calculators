using GeometricCalculators;
using GeometricCalculators.Shapes;
using NUnit.Framework;

namespace GeometricCalculators.Tests
{
    [TestFixture]
    public class PolygonCalculatorTests
    {
        Dot[] dots;
        PolygonCalculator calculator;
        
        [SetUp]
        public void SetDots()
        {
            dots = new Dot[4];
            dots[0] = new Dot(1,1);
            dots[1] = new Dot(3, 5);
            dots[2] = new Dot(5, 2);
            dots[3] = new Dot(3, 2);
        }

        /*
               Y
               ^
             5 |         *
               |        .  .
               |      .      . 
             2 |     . . * -- *
             1 |    *
               |----|----|----|--> X
                    1    3    5

               X   Y
               1 - 1
               3 - 5
               5 - 2
               3 - 2

            x1 = 1   y1 = 1
            x2 = 3   y2 = 5
            x3 = 5   y3 = 2
            x4 = 3   y4 = 2

            2S = (x1y2 - x2y1) + (x2y3 - x3y2) + (x3y4 - x4y3) + (x4y1 - x1y4)
            2S = (1*5 - 3*1) + (3*2 - 5*5) + (5*2 - 3*2) + (3*1 - 1*2)
            2S = (5-3) + (6 - 25) + (10 - 6) + (3 - 2)
            2S = 2 - 19 + 4 + 1
            2S = -12
            S = -12 / 2 = - 6 =  Math.Abs(-6) = 6
        */
        [Test]
        [TestCase(6)]
        public void GetPolygonArea(float result)
        {
            calculator = new PolygonCalculator(dots);
            var res = calculator.Area();
            Assert.AreEqual(result, res);
        }
    }
}
