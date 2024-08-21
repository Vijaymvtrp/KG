using H_M.Data;
using H_M.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace H_M.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetBookingsController : ControllerBase
    {
     private readonly AppDbContext _Context;

    public  GetBookingsController(AppDbContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bookings>>> GetBookings()
        {
            var bookingData = await _Context.Bookings.ToListAsync();

            if (bookingData != null && bookingData.Count != 0)
            {
                return Ok(bookingData);
            }
            else
            {
                return BadRequest(new { message = "There is no rooms in the hotel" });
            }


        }
        [HttpPost]
        public async Task<ActionResult<Bookings>> PostBooking(Bookings booking)
        {
            if (booking == null)
            {
                return BadRequest(new { message = "Invalid booking data." });
            }

            try
            {
                _Context.Bookings.Add(booking);
                await _Context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetBookings), new { id = booking.BookingId }, booking);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while saving the booking.", error = ex.Message });
            }
        }

        [HttpPut("BookingId")]

        public async Task<IActionResult> EditTransaction(int BookingId, Bookings bookings)
        {
            if (BookingId != bookings.BookingId)
            {
                return BadRequest(new { message = $"please create the transaction {BookingId}" });
            }
            try
            {
                _Context.Entry(bookings).State = EntityState.Modified;

                await _Context.SaveChangesAsync();
                return Ok(new { message = $"Transaction edited successfully for {BookingId}" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }

    }
}
