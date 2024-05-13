using Common;
using Logic;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class RectangleController : ControllerBase
{
    private readonly ILogger<RectangleController> _logger;

    private readonly IRectangleService _rectangleService;

    public RectangleController(ILogger<RectangleController> logger, IRectangleService rectangleService)
    {
        _logger = logger;
        _rectangleService = rectangleService;
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
        return _rectangleService.GetIntersected(request);
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
        _rectangleService.GenerateList(amount);
    }
#endif

}
