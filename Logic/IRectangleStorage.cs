using Common;

namespace Logic;

public interface IRectangleStorage
{
    RectangleView[] GetIntersected(IBoundingRectangle searchingSegment);

#if DEBUG
    void GenerateList(int amount);
#endif 

}