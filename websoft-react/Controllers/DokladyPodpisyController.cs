using Microsoft.AspNetCore.Mvc;
using websoft_react.ModelView;


[ApiController]
[Route("api/[controller]")]
public class DokladyPodpisyController : ControllerBase
{
    private readonly WebDBContext _context;

    public DokladyPodpisyController(WebDBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DokladyPodpisyView>>> GetDokladyPodpisy()
    {
        return await _context.Doklady.ToListAsync();
    }
}
