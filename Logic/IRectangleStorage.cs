using Common;

namespace Logic;

public interface IRectangleStorage
{
    RectangleView[] GetRectangles(IBoundingRectangle searchingSegment);

#if DEBUG
    void Recreate(int amount);
#endif 

}