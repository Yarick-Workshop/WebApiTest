using Common;
using DAL;

namespace Logic.Tests;

[TestClass]
public class RectangleService_GetIntersectedAsync_Tests
{
    [TestMethod]
    public async Task When_intersect_even_in_a_vertex_Then_returns_rectangles()
    {
        using var container = new InMemoryContextContainer();

        container.Context.Rectangles.AddRange(
            new []
            {
                // top left
                new Rectangle
                {
                    MinX = -10,
                    MaxX = 0,

                    MinY = 1,
                    MaxY = 10
                },

                // bottom left
                new Rectangle
                {
                    MinX = -10,
                    MaxX = 0,

                    MinY = -10,
                    MaxY = 0
                },

                // top right
                new Rectangle
                {
                    MinX = 1,
                    MaxX = 10,

                    MinY = 1,
                    MaxY = 10
                },

                // bottom right
                new Rectangle
                {
                    MinX = 1,
                    MaxX = 10,

                    MinY = -10,
                    MaxY = 0
                }
            }
        );
        await container.Context.SaveChangesAsync();

        var rectangleService = new RectangleService(container.Context);

        var rectangles = await rectangleService.GetIntersectedAsync(new GetRectanglesRequest
        {
            MinX = 0,
            MaxX = 1,
            
            MinY = 0,
            MaxY = 1
        });

        Assert.AreEqual(4, rectangles.Length);
    }

    [TestMethod]
    public async Task When_rectangle_in_another_one_Then_returns_rectangles()
    {
        using var container = new InMemoryContextContainer();

        container.Context.Rectangles.AddRange(
            new []
            {
                // the same coords "one-to-one"
                new Rectangle
                {
                    MinX = 0,
                    MaxX = 1,
                    MinY = 0,
                    MaxY = 1
                },

                // rectangle inside searching one
                new Rectangle
                {
                    MinX = 0.3,
                    MaxX = 0.6,

                    MinY = 0.3,
                    MaxY = 0.6
                },

                // rectangle contains searching one
                new Rectangle
                {
                    MinX = -1,
                    MaxX = 10,

                    MinY = -1,
                    MaxY = 10
                }                
            }

        );
        await container.Context.SaveChangesAsync();

        var rectangleService = new RectangleService(container.Context);

        var rectangles = await rectangleService.GetIntersectedAsync(new GetRectanglesRequest
        {
            MinX = 0,
            MaxX = 1,

            MinY = 0,
            MaxY = 1,
        });

        Assert.AreEqual(3, rectangles.Length);
    }

    [TestMethod]
    public async Task When_rectangles_do_not_intersect_Then_returns_empty()
    {
        using var container = new InMemoryContextContainer();

        container.Context.Rectangles.AddRange(
            new []
            {
                 // top left
                new Rectangle
                {
                    MinX = -10,
                    MaxX = -0.0001,

                    MinY = 1,
                    MaxY = 10
                },

                // bottom left
                new Rectangle
                {
                    MinX = -10,
                    MaxX = -0.0001,

                    MinY = -10,
                    MaxY = 0
                },

                // top right
                new Rectangle
                {
                    MinX = 1.0001,
                    MaxX = 10,

                    MinY = 1,
                    MaxY = 10
                },

                // bottom right
                new Rectangle
                {
                    MinX = 1.0001,
                    MaxX = 10,

                    MinY = -10,
                    MaxY = 0
                }
            }

        );
        await container.Context.SaveChangesAsync();

        var rectangleService = new RectangleService(container.Context);

        var rectangles = await rectangleService.GetIntersectedAsync(new GetRectanglesRequest
        {
            MinX = 0,
            MaxX = 1,

            MinY = 0,
            MaxY = 1,
        });

        Assert.AreEqual(0, rectangles.Length);
    }
}