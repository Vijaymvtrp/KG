using Microsoft.AspNetCore.Mvc;
using H_M.Data;
using H_M.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;


namespace H_M.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowAllOrigins")]
    public class GetRoomsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GetRoomsController(AppDbContext context)
        { 
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rooms>>> GetRooms()
        {
            var roomsData = await _context.Rooms.ToListAsync();

            if (roomsData != null && roomsData.Count != 0)
            {
                return Ok(roomsData);
            }
            else
            {
                return BadRequest(new { message = "There is no rooms in the hotel" });
            }


        }

        [HttpPost]

        public async Task<ActionResult<Rooms>> RoomsCreation(Rooms rooms)
        {
            if (rooms == null)
            {
                return BadRequest(new { message = " Invalid room data" });
            }
            try
            {
                _context.Rooms.Add(rooms);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetRooms), rooms);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = " An occured while saving the room.",error = ex.Message });
            }
        }
        [HttpPut("RoomId")]

        public async Task<IActionResult> EditTransaction(int RoomId, Rooms rooms)
        {
            if (RoomId != rooms.RoomId)
            {
                return BadRequest(new { message = $"please create the transaction {RoomId}" });
            }
            try
            {
                _context.Entry(rooms).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return Ok(new { message = $"Room edited successfully for {RoomId}" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
    }
}
