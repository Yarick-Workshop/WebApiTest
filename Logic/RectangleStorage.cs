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
        //TODO unit tests for parameters validation
        if (searchingSegment.MinX >= searchingSegment.MaxX)
        {
            throw new ArgumentException($"MaxX hast to be > MinX.");
        }

        if (searchingSegment.MinY >= searchingSegment.MaxY)
        {
            throw new ArgumentException($"MaxY hast to be > MinY.");
        }

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

#if DEBUG
    public void Recreate(int amount)
    {
        if (amount <= 0 || amount > 1000)
        {//TODO tests
            throw new ArgumentOutOfRangeException(nameof(amount));
        }

        // Truncate Table
        _dbContext.Rectangles.RemoveRange(_dbContext.Rectangles);

        // Random rectangles generation        
        var newRectangles = Enumerable.Range(1, amount)
            .Select(x =>
            {      
                
                var res = new Rectangle
                {
                    MinX = Random.Shared.Next(1000),
                    MinY = Random.Shared.Next(1000),
                };

                res.MaxX = res.MinX + Random.Shared.Next(1, 1000);
                res.MaxY = res.MinY + Random.Shared.Next(1, 1000);

                return res;
            });

        _dbContext.Rectangles.AddRange(newRectangles);

        _dbContext.SaveChanges();
    }
#endif 
}
