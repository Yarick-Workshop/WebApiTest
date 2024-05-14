using Common;
namespace Logic.Tests;

[TestClass]
public class RectangleService_ParameterValidationTests
{
    [TestMethod]
    [DataRow(10.0, 10.0)]
    [DataRow(11.0, 10.0)]
    public async Task GetIntersectedAsync_When_MinX_is_More_or_equal_MaxX_Then_Throws_ArgumentException(double minX, double maxX)
    {
        var request = new GetRectanglesRequest
        {
            MinX = minX,
            MaxX = maxX,

            MinY = 0,
            MaxY = 10,
        };

        using var context = Helper.CreateInMemoryContext();

        var service = new RectangleService(context);

        var ex = await  Assert.ThrowsExceptionAsync<ArgumentException>(() => service.GetIntersectedAsync(request));

        Assert.AreEqual("MaxX hast to be > MinX.", ex.Message);
    }

    [TestMethod]
    [DataRow(10.0, 10.0)]
    [DataRow(11.0, 10.0)]
    public async Task GetIntersectedAsync_When_MinY_is_More_or_equal_MaxY_Then_Throws_ArgumentException(double minY, double maxY)
    {
        var request = new GetRectanglesRequest
        {
            MinX = 0,
            MaxX = 10,

            MinY = minY,
            MaxY = maxY,
        };

        using var context = Helper.CreateInMemoryContext();

        var service = new RectangleService(context);

        var ex = await Assert.ThrowsExceptionAsync<ArgumentException>(() => service.GetIntersectedAsync(request));

        Assert.AreEqual("MaxY hast to be > MinY.", ex.Message);
    }

#if DEBUG
    [TestMethod]
    [DataRow(-1)]
    [DataRow(0)]
    [DataRow(1001)]
    [DataRow(10000)]
    public async Task GenerateListAsync_When_wrong_rectangle_amount_Then_Throws_ArgumentOutOfRangeException(int amount)
    {
        using var context = Helper.CreateInMemoryContext();

        var service = new RectangleService(context);

        var ex = await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(() => service.GenerateListAsync(amount));

        Assert.AreEqual("Has to be between 1 and 1000 (Parameter 'amount')", ex.Message);
    }
#endif
}