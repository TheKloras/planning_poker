using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanningPokerAPI.Data;
using PlanningPokerAPI.Models;

namespace PlanningPokerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardConfigController : ControllerBase
    {
        private static List<CardConfig> cards = new List<CardConfig>
        {
            new CardConfig { Id = 1, Value = "Initial Config String"}
        };
        private readonly DataContext _context;

        public CardConfigController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("get")]
        public async Task<ActionResult<List<CardConfig>>> Get()
        {
            return Ok(await _context.ConfigTable.ToListAsync());
        }

        [HttpPut("put")]
        public async Task<ActionResult<List<CardConfig>>> UpdateConfig(CardConfig request)
        {
            var dbcard = await _context.ConfigTable.FindAsync(request.Id);
            if (dbcard == null)
                return BadRequest("Card not found");
            dbcard.Value = request.Value;

            await _context.SaveChangesAsync();
            return Ok(await _context.ConfigTable.ToListAsync());
        }

    }
}