using DAL;

namespace Logic.Tests;

#if DEBUG
[TestClass]
public class RectangleService_GenerateListAsync_Tests
{
    [TestMethod]
    [DataRow(1)]
    [DataRow(10)]
    [DataRow(500)]
    [DataRow(999)]
    [DataRow(1000)]
    public async Task When_correct_parameter_range_Then_creates_rectangle_list(int amount)
    {
        using var container = new InMemoryContextContainer();
        
        var service = new RectangleService(container.Context);

        await service.GenerateListAsync(amount);

        var amountIndDb = container.Context.Rectangles.Count();
        Assert.AreEqual(amount, amountIndDb);

        var emptyRectanglesAmount = container.Context.Rectangles
            .Count(x => x.MinX == x.MaxX || x.MinY == x.MaxY);
        Assert.AreEqual(0, emptyRectanglesAmount);   
    }
}

#endif