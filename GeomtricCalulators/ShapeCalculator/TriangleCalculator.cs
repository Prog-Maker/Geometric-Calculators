namespace GeometricCalculators
{
    using GeometricCalculators.Shapes;
    public class TriangleCalculator : ShapeCalculator
    {
        public enum CalcAreaType
        {
            TreeSide,
            TwoSidesAndAngleBetweenThem,
            SideAndHeigth,
        }

        private Triangle Shape;

        public CalcAreaType CalcType { get; private set; }

        public override string Name => "Triangle";

        public TriangleCalculator(CalcAreaType calcType, double a_Side = 0,
                                                         double b_Side = 0,
                                                         double c_Side = 0,
                                                         double angle = 0,
                                                         double heigth = 0)
        {
            CalcType = calcType;
            Shape = new Triangle(a_Side, b_Side, c_Side, angle, heigth);
        }

        public double GetArea()
        {
            double s = 0;
            switch (CalcType)
            {
                case CalcAreaType.TreeSide:
                    s = Shape.GetAreaFromTreeSides();
                    break;
                case CalcAreaType.TwoSidesAndAngleBetweenThem:
                    s = Shape.GetAreaFromTwoSidesAndAngleBetweenThem();
                    break;
                case CalcAreaType.SideAndHeigth:
                    s = Shape.GetAreaFromSideAndHeigth();
                    break;
            }
            return s;
        }

        public bool IsTriangleRectangular 
        {
            get => Shape.IsTriangleRectangular();
        }

        public override double Area() 
        {
            return GetArea();
        }
    }

    public interface IGeometricOperation
    {

    }
}
