namespace Common;

public class Rectangle : IBoundingRectangle
{
    public int Id { get; set; }

    public double MinX { get; set; }

    public double MinY { get; set; }

    public double MaxX { get; set; }

    public double MaxY { get; set; }
}
