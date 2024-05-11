namespace Common;

public class GetRectanglesRequest : IBoundingRectangle
{
    public double MinX { get; set; }

    public double MinY { get; set; }

    public double MaxX { get; set; }

    public double MaxY { get; set; }
}