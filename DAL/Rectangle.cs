using Common;
using Microsoft.EntityFrameworkCore;

namespace DAL;

[Index(nameof(MinX), nameof(MinY), nameof(MaxX), nameof(MaxY))]
public class Rectangle : IBoundingRectangle
{
    public int RectangleId { get; set; }
    
    public double MinX { get; set; }

    public double MinY { get; set; }

    public double MaxX { get; set; }

    public double MaxY { get; set; }
}
