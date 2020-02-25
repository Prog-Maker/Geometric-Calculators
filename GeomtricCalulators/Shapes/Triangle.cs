namespace GeometricCalculators.Shapes
{
    using System;
    public class Triangle : Shape
    {
        public double A_Side { get; private set; }
        public double B_dSide { get; private set; }
        public double C_Side { get; private set; }
        public double Angle { get; private set; }
        public double Heigth { get; private set; }



        public Triangle(double a_Side = 0, double b_Side = 0, double c_Side = 0,
                                                   double angle = 0, double heigth = 0)
        {
            A_Side = a_Side;
            B_dSide = b_Side;
            C_Side = c_Side;
            Angle = angle;
            Heigth = heigth;
        }



        /// <summary>
        /// Получеат площадь по трем сторонам. Формура Герона
        /// </summary>
        /// <returns>площадь</returns>
        public double GetAreaFromTreeSides()
        {
            //if (ThirdSide > (FirtsSide + SecondSide)) 
            //           throw new ArgumentException("Such a triangle does not exist!");

            GetError(() => C_Side > (A_Side + B_dSide), "Such a triangle does not exist!");

            var p = (A_Side + B_dSide + C_Side) / 2;

            return Math.Sqrt(p * (p - A_Side) * (p - B_dSide) * (p - C_Side));
        }

        /// <summary>
        /// Получает площадь по двум сторонам и углу между ними
        /// </summary>
        /// <returns>площадь</returns>
        public double GetAreaFromTwoSidesAndAngleBetweenThem()
        {
            GetError(() => Angle > 179, "Such a triangle does not exist!");

            GetError(() => IsAllSidesAreZero(A_Side, B_dSide, C_Side), "More whan 1 Side zero");

            double first_Side = 0;
            double second_Side = 0;

            if (A_Side > 0 && C_Side > 0)
            {
                second_Side = A_Side;
                first_Side = C_Side;
            }
            else if (A_Side > 0 && B_dSide > 0)
            {
                second_Side = A_Side;
                first_Side = B_dSide;
            }
            else if (B_dSide > 0 && C_Side > 0)
            {
                second_Side = B_dSide;
                first_Side = C_Side;
            }

            return ((second_Side * first_Side) / 2) * Math.Sin(Math.PI * Angle / 180);
        }

        /// <summary>
        /// Получает площать по одной стороне и опущенной на нее высоте
        /// </summary>
        /// <returns></returns>
        
        public double GetAreaFromSideAndHeigth()
        {
            return A_Side / 2 * Heigth;
        }

        /// <summary>
        /// Получаем булево значение, является ли треугольник прямоугольным
        /// </summary>
        /// <returns></returns>
        public bool IsTriangleRectangular()
        {
            if (IsAllSidesAreZero(A_Side, B_dSide, C_Side))
            {
                return false;
            }

            var res1 = ChekHypotenuse(A_Side, B_dSide, C_Side);
            var res2 = ChekHypotenuse(B_dSide, A_Side, C_Side);
            var res3 = ChekHypotenuse(C_Side, A_Side, B_dSide);

            return  res1 || res2 || res3;  
        }

        private bool ChekHypotenuse(double cathet1, double cathet2, double potentialHypotenuse)
        {
            var hypotenuseTemp = Math.Pow(cathet1, 2) + Math.Pow(cathet2, 2);
            var result = Math.Sqrt(hypotenuseTemp);
            return potentialHypotenuse == result;
        }


        private void GetError(Func<bool> predicate, string message)
        {
            if (predicate.Invoke())
            {
                throw new ArgumentException(message);
            }
        }

        private bool IsAllSidesAreZero(params double[] sides)
        {
            int couunter = 0;
            for (int i = 0; i < sides.Length; i++)
            {
                if (sides[i] > 0)
                {
                    couunter++;
                    if (couunter > 1)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
