using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Travel.Data.Contexts;
using Travel.Domain.Entities;

namespace Travel.WebApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TourListsController : ControllerBase
  {
    private readonly TravelDbContext _context;

    public TourListsController(TravelDbContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
      return Ok(_context.TourLists);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TourList tourList)
    {
      await _context.TourLists.AddAsync(tourList);
      await _context.SaveChangesAsync();

      return Ok(tourList);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
      var tourList = await _context.TourLists.SingleOrDefaultAsync(tl => tl.Id == id);

      if (tourList == null)
      {
        return NotFound();
      }

      _context.TourLists.Remove(tourList);
      await _context.SaveChangesAsync();

      return Ok(tourList);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TourList tourList)
    {
      _context.Update(tourList);

      await _context.SaveChangesAsync();

      return Ok(tourList);
    }
  }
}