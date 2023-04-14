using Microsoft.AspNetCore.Mvc;
using PlanningPokerAPI.Models;


namespace PlanningPokerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomCardClearController : ControllerBase
    {
        //private static List<CardClear> cardClears = new List<CardClear>
        //{
        //    new CardClear { Id = 1, Clear = false}
        //};
        private readonly DataContext _context;
        public RoomCardClearController(DataContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<List<RoomCardClear>>> AddClear(RoomCardClear clear)
        {
            _context.RoomCardClearTable.Add(clear);
            await _context.SaveChangesAsync();
            return Ok(await _context.RoomCardClearTable.ToListAsync());
        }
        [HttpGet("{configRoom}")]
        public async Task<ActionResult<RoomCardClear>> Get(string configRoom)
        {
            var dbclear = await _context.RoomCardClearTable.FindAsync(configRoom);
            if (dbclear == null)
                return BadRequest("No Clear");
            return Ok(dbclear);
        }
        [HttpGet("get")]
        public async Task<ActionResult<List<RoomCardClear>>> Get()
        {
            return Ok(await _context.RoomCardClearTable.ToListAsync());
        }
        [HttpPut("put")]
        public async Task<ActionResult<List<RoomCardClear>>> UpdateClear(RoomCardClear request)
        {
            var dbclear = await _context.RoomCardClearTable.FindAsync(request.ClearRoom);
            if (dbclear == null)
                return BadRequest("Clear not found");
            dbclear.RoomClear = request.RoomClear;

            await _context.SaveChangesAsync();
            return Ok(await _context.RoomCardClearTable.ToListAsync());
        }
    }
}
