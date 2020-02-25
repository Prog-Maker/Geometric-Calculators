namespace GeometricCalculators.Shapes
{
    using System;
    public class Circle : Shape
    {
        const double pi = 3.14;

        public double Radius { get; private set; }

        public double Diametr { get; private set; }

        public double Legth { get; private set; }

        public Circle(double radius = 0, double diametr = 0, double length = 0)
        {
            Radius = radius;
            Diametr = diametr;
            Legth = length;
        }

        /// <summary>
        /// Получаем площадь круга через радиус
        /// </summary>
        /// <returns>площадь</returns>
        public double GetAreaFromRadius()
        {
            GetError(Radius, nameof(Radius));
            return Math.Pow(Radius, 2) * pi;
        }

        /// <summary>
        /// Получаем площадь круга через диаметр
        /// </summary>
        /// <returns>площадь</returns>
        public double GetAreaFromDiametr()
        {
            GetError(Diametr, nameof(Diametr));
            return (pi * Math.Pow(Diametr, 2)) / 4;
        }

        /// <summary>
        /// Получаем площадь круга через длину окружности
        /// </summary>
        /// <returns>площадь</returns>
        public double GetAreafromLegth()
        {
            GetError(Legth, nameof(Legth));
            return Math.Pow(Legth, 2) / (4 * pi);
        }

        /// <summary>
        /// Проверяем параметр на положительное число
        /// </summary>
        /// <param name="arg">параметр</param>
        /// <param name="argName">имя параметра</param>
        private void GetError(double arg, string argName)
        {
            if (arg < 1)
                throw new ArgumentException($"{argName} must be positive number");
        }
    }
}
