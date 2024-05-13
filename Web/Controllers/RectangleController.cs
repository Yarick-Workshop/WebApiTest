using Common;
using Logic;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class RectangleController : ControllerBase
{
    private readonly ILogger<RectangleController> _logger;

    private readonly IRectangleStorage _rectangleStorage;

    public RectangleController(ILogger<RectangleController> logger, IRectangleStorage rectangleStorage)
    {
        _logger = logger;
        _rectangleStorage = rectangleStorage;
    }

    /// <summary>
    /// Fetches list of rectangles which intersect correspond searching rectangle
    /// 
    /// POST /Rectangle/GetIntersected
    /// </summary>
    /// <param name="request">Searching rectangle</param>
    /// <returns>Lits of rectangles</returns>
    [HttpPost]
    public IEnumerable<RectangleView> GetIntersected(GetRectanglesRequest request)
    {
        return _rectangleStorage.GetIntersected(request);
    }

#if DEBUG
    /// <summary>
    /// Creates list of rectangles with random parameters
    /// 
    /// PUT /Rectangle/GenerateList
    /// </summary>
    /// <param name="amount">How many random rectangles to create</param>
    [HttpPut]
    public void GenerateList(int amount)
    {
        _rectangleStorage.GenerateList(amount);
    }
#endif

}
