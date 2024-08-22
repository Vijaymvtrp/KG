using H_M.Data;
using H_M.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace H_M.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TranscationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TranscationsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetTranscationsByRoom")]
        public async Task<IActionResult> GetTranscationsByRoom()
        {
            var query = @"
                          SELECT 
                                    b.booking_id,
	                                b.room,
	                                b.room_type,
	                                b.user_name,
	                                b.mobile_number,
	                                t.amount_paid_date as date,
	                                t.amount,
	                                t.status,
	                                t.payment_mode,
	                                t.Transaction_Id
                         FROM bookings as b
                         INNER JOIN transactions as t on t.booking_id = b.booking_id;";

            var transactionByRooms = await _context.transactionByRooms
                                                 .FromSqlRaw(query)
                                                 .ToListAsync();

            try
            {
                if (transactionByRooms.Count > 0)
                {
                    return Ok(transactionByRooms);
                }
                else
                {
                    return BadRequest(new { message = $"There is no transcations for booking room" });
                }
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }


            
        }

    }
}
