using Common;
using Logic;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class RectangleController : ControllerBase
{
    private readonly ILogger<RectangleController> _logger;

    private readonly IRectangleStorage _rectangleStorage;

    public RectangleController(ILogger<RectangleController> logger, IRectangleStorage rectangleStorage)
    {
        _logger = logger;
        _rectangleStorage = rectangleStorage;
    }

    [HttpPost(Name = "GetRectangles")]
    public IEnumerable<RectangleView> Get(GetRectanglesRequest request)
    {
        return _rectangleStorage.GetRectangles(request);
    }

#if DEBUG
    [HttpPut(Name = "RecreateRectangles")]
    public void Recreate(int amount)
    {
        _rectangleStorage.Recreate(amount);
    }
#endif

}
