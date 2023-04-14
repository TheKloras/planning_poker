using Microsoft.AspNetCore.Mvc;
using PlanningPokerAPI.Models;


namespace PlanningPokerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardClearController : ControllerBase
    {
        private static List<CardClear> cardClears = new List<CardClear>
        {
            new CardClear { Id = 1, Clear = false}
        };
        private readonly DataContext _context;
        public CardClearController(DataContext context)
        {
            _context = context;
        }
        [HttpGet("get")]
        public async Task<ActionResult<List<CardClear>>> Get()
        {
            return Ok(await _context.CardClearTable.ToListAsync());
        }
        [HttpPut("put")]
        public async Task<ActionResult<List<CardClear>>> UpdateClear(CardClear request)
        {
            var dbclear = await _context.CardClearTable.FindAsync(request.Id);
            if (dbclear == null)
                return BadRequest("Clear not found");
            dbclear.Clear = request.Clear;

            await _context.SaveChangesAsync();
            return Ok(await _context.CardClearTable.ToListAsync());
        }
    }
}
