namespace GeometricCalculators
{
    using GeometricCalculators.Shapes;

    public class CircleCalculator : ShapeCalculator
    {
        public enum CircleParametrType
        {
            Radius, Diametr, Length
        }

        private Circle Shape;

        private CircleParametrType circleParametrType;

        public override string Name { get; } = "Triangle";

        public CircleCalculator(CircleParametrType circleParametrType, double radius = 0,
                                                                       double diametr = 0, 
                                                                       double length = 0)
        {
            Shape = new Circle(radius, diametr, length);
            this.circleParametrType = circleParametrType;
        }

        public CircleCalculator(Circle circle)
        {
            Shape = circle;
        }

        private double GetArea()
        {
            double s = 0;

            switch (circleParametrType)
            {
                case CircleParametrType.Radius:
                    s = Shape.GetAreaFromRadius();
                    break;
                case CircleParametrType.Diametr:
                    s = Shape.GetAreaFromDiametr();
                    break;
                case CircleParametrType.Length:
                    s = Shape.GetAreafromLegth();
                    break;
            }

            return s;
        }

        public override double Area()
        {
           return GetArea();
        }
    }
}
