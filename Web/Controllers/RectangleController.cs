using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class RectangleController : ControllerBase
{
    private readonly ILogger<RectangleController> _logger;

    public RectangleController(ILogger<RectangleController> logger)
    {
        _logger = logger;
    }

    [HttpPost(Name = "GetRectangles")]
    public IEnumerable<Rectangle> Get()
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
        .ToArray();
    }
}
