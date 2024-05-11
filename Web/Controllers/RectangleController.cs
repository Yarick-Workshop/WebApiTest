using Common;
using Logic;
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
        //TODO inject:
        return new RectangleStorage().GetRectangles();
    }
}
