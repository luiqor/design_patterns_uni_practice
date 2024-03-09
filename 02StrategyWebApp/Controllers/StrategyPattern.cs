namespace _02StrategyWebApp.Controllers
{
    public interface IRegularPolygonStrategy
    {
        double calcArea(double side);
    }
    public class TriangleStrategy : IRegularPolygonStrategy
    {
        public double calcArea(double side)
        {
            // the formula for the area of an equilateral triangle is sqrt(3) * side^2 / 4
            double area = Math.Sqrt(3) * Math.Pow(side, 2) / 4;
            return area;
        }
    }
    public class QuadrangleStrategy : IRegularPolygonStrategy
    {
        public double calcArea(double side)
        {
            // the formula for the area of a square is side^2
            double area = Math.Pow(side, 2);
            return area;
        }
    }
    public class HexagonStrategy : IRegularPolygonStrategy
    {
        public double calcArea(double side)
        {
            // the formula for the area of a regular hexagon is 3 * sqrt(3) * side^2 / 2
            double area = 3 * Math.Sqrt(3) * Math.Pow(side, 2) / 2;
            return area;
        }
    }

    public class OctagonStrategy : IRegularPolygonStrategy
    {
        public double calcArea(double side)
        {
            // the formula for the area of a regular octagon is 2 * (1 + sqrt(2)) * side^2
            double area = 2 * (1 + Math.Sqrt(2)) * Math.Pow(side, 2);
            return area;
        }
    }
    public class CalculatorContext
    {
        protected internal double side;
        public CalculatorContext(double length, IRegularPolygonStrategy strategy)
        {
            this.side = length;
            ContextStrategy = strategy;
        }
        public IRegularPolygonStrategy ContextStrategy { get; set; }
        public double ExecuteCalcArea()
        {
            return ContextStrategy.calcArea(side);
        }
    }


}
