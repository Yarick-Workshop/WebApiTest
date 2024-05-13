using Common;
using DAL;

namespace Logic;

public class RectangleStorage : IRectangleStorage
{
    private readonly TestDbContext _dbContext;

    public RectangleStorage(TestDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public RectangleView[] GetRectangles(IBoundingRectangle searchingSegment)
    {
        return _dbContext.Rectangles
        .Where(x => x.MinX <= searchingSegment.MaxX && 
                    x.MinY <= searchingSegment.MaxY &&
                    
                    x.MaxX >= searchingSegment.MinX &&
                    x.MaxY >= searchingSegment.MinY)
        //TODO I see no reason to use mapping as there are only 5 fields 
        // and it is just a test project
        .Select(x => new RectangleView{
            Id = x.RectangleId,
            
            MinX = x.MinX,
            MinY = x.MinY,

            MaxX = x.MaxX,
            MaxY = x.MaxY,
        })
        .ToArray();
    }
}
