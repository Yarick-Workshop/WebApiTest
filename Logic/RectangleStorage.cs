using Common;

namespace Logic;

public class RectangleStorage : IRectangleStorage
{
    public Rectangle[] GetRectangles(IBoundingRectangle searchingSegment)
    {
        return Enumerable.Range(1, 5).Select(index => 
        {
            var res = new Rectangle
            {
                Id = index,
                MinX = Random.Shared.Next(1000),
                MinY = Random.Shared.Next(1000),
            };

            res.MaxX = res.MinX + Random.Shared.Next(1000);
            res.MaxY = res.MinY + Random.Shared.Next(1000);

            return res;
        })
        .Where(x => x.MinX <= searchingSegment.MaxX && 
                    x.MinY <= searchingSegment.MaxY &&
                    
                    x.MaxX >= searchingSegment.MinX &&
                    x.MaxY >= searchingSegment.MinY)
        .ToArray();
    }
}
