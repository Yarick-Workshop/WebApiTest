namespace Common;

public interface IBoundingRectangle
{
    double MinX { get; set; }

    double MinY { get; set; }

    double MaxX { get; set; }

    double MaxY { get; set; }
}