using H_M.Data;
using H_M.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace H_M.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetRemindersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GetRemindersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reminders>>> GetReminders()
        {
            var reminders = await _context.Reminders.ToListAsync();

            if (reminders == null || reminders.Count == 0)
            {
                return Ok(new { message = "There is no reminders up to now!" });
            }
            else
            {
                return Ok(reminders);
            }
        }

        [HttpPost]

        public async Task<ActionResult<Reminders>> PostReminder(Reminders reminders)
        {
            if(reminders == null)
            {
                return BadRequest(new { message = " Invalid reminder data" });
            }
            try
            {
                _context.Reminders.Add(reminders);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetReminders), reminders);
            }
            catch (Exception ex)
            {
                return StatusCode(500 , new { message = "An error occured while saving the reminder", error = ex.Message });
            }
        }

        [HttpPut("id")]

        public async Task<IActionResult> EditReminders(int id, Reminders reminders)
        {
            if (id != reminders.Id)
            {
                return BadRequest(new { message = $"please create the transaction {id}" });
            }
            try
            {
                _context.Entry(reminders).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return Ok(new { message = $"Reminder edited successfully for {id}" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
    }

}
