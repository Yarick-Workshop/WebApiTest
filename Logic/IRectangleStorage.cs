using Common;

namespace Logic;

public interface IRectangleStorage
{
    Rectangle[] GetRectangles(IBoundingRectangle searchingSegment);
}