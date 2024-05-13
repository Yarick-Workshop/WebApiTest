using Common;

namespace Logic;

public interface IRectangleService
{
    Task<RectangleView[]> GetIntersectedAsync(IBoundingRectangle searchingSegment);

#if DEBUG
    Task GenerateListAsync(int amount);
#endif 

}