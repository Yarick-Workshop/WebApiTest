using Common;

namespace Logic;

public interface IRectangleStorage
{
    RectangleView[] GetRectangles(IBoundingRectangle searchingSegment);
}