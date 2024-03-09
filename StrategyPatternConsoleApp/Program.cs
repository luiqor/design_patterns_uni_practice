public interface IRegularPolygonStrategy
{
    void calcArea(double side);
}
public class TriangleStrategy : IRegularPolygonStrategy
{
    public void calcArea(double side)
    {
        // the formula for the area of an equilateral triangle is sqrt(3) * side^2 / 4
        double area = Math.Sqrt(3) * Math.Pow(side, 2) / 4;
        Console.WriteLine("The area of the triangle is {0}", area);
    }
}
public class QuadrangleStrategy : IRegularPolygonStrategy
{
    public void calcArea(double side)
    {
        // the formula for the area of a square is side^2
        double area = Math.Pow(side, 2);
        Console.WriteLine("The area of the quadrangle is {0}", area);
    }
}
public class HexagonStrategy : IRegularPolygonStrategy
{
    public void calcArea(double side)
    {
        // the formula for the area of a regular hexagon is 3 * sqrt(3) * side^2 / 2
        double area = 3 * Math.Sqrt(3) * Math.Pow(side, 2) / 2;
        Console.WriteLine("The area of the hexagon is {0}", area);
    }
}

public class OctagonStrategy : IRegularPolygonStrategy
{
    public void calcArea(double side)
    {
        // the formula for the area of a regular octagon is 2 * (1 + sqrt(2)) * side^2
        double area = 2 * (1 + Math.Sqrt(2)) * Math.Pow(side, 2);
        Console.WriteLine("The area of the octagon is {0}", area);
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
    public void ExecuteCalcArea()
    {
        ContextStrategy.calcArea(side);
    }
}

class Program
{
    static void Main()
    {
        var triangle = new CalculatorContext(10, new TriangleStrategy());
        triangle.ExecuteCalcArea();

        var quadrangle = new CalculatorContext(10, new QuadrangleStrategy());
        quadrangle.ExecuteCalcArea();

        var hexagon = new CalculatorContext(10, new HexagonStrategy());
        hexagon.ExecuteCalcArea();

        var octagon = new CalculatorContext(10, new OctagonStrategy());
        octagon.ExecuteCalcArea();
    }
}