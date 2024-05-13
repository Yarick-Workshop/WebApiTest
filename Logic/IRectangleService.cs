using Common;

namespace Logic;

public interface IRectangleService
{
    RectangleView[] GetIntersected(IBoundingRectangle searchingSegment);

#if DEBUG
    void GenerateList(int amount);
#endif 

}