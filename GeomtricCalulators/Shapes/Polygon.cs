using System;
using System.Collections.Generic;
using System.Text;

namespace GeometricCalculators.Shapes
{
    public class Polygon : Shape
    {
        private Dot[] dots;
        public Polygon(Dot[] dots)
        {
            this.dots = dots;
        }

        public double GetArea()
        {
            if (dots == null) return 0;
            
            double area = default(double);

            for (int i = 0; i < dots.Length - 1; i++)
            {
                area += dots[i].X * dots[i + 1].Y - dots[i].Y * dots[i + 1].X;
            }
            // Не забываем, что ломаная должна быть замкнутой:
            area += dots[dots.Length - 1].X * dots[0].Y - dots[dots.Length - 1].Y * dots[0].X;

            return Math.Abs(area) / 2;
        }
    }

    public struct Dot
    {
        public Dot(float x, float y)
        {
            X = x;
            Y = y;
        }
        
        public float X;

        public float Y;
    }
}
