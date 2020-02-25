namespace GeometricCalculators
{
    using GeometricCalculators.Shapes;
    public class PolygonCalculator : ShapeCalculator
    {
        string name = "Polygon";
        
        Polygon polygon;

        public PolygonCalculator(Dot[] dots)
        {
            polygon = new Polygon(dots);
        }

        public override string Name => name;

        public override double Area()
        {
           return polygon.GetArea();
        }
    }
}
