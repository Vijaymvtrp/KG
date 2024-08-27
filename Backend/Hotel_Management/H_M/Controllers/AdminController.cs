using H_M.Data;
using H_M.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace H_M.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowAllOrigins")]
    public class AdminController : ControllerBase
    {
     private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Admin>>> GetAdmins()
        {
            var admins = await _context.Admin.ToListAsync();

            if (admins == null || admins.Count == 0)
            {
                return Ok(new { message = "No Users/Admins are created upto now " });

            }
            else
            {
                return Ok(admins);
            }
            
        }

        [HttpPost]

        public async Task<ActionResult<Admin>> AdminCreation(Admin admin)
        {
            if (admin == null)
            {
                return BadRequest(new { message = "Invalid admin data" });
            }
            try
            {
                _context.Admin.Add(admin);
                await _context.SaveChangesAsync();
                return  Ok(admin);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = " An occured while saving the Admin", error = ex.Message });
            }
        }

        [HttpPut]

        public async Task<IActionResult> EditAdmin(int id, Admin admin)
        {
            if (id != admin.Id)
            {
                return BadRequest(new { message = $"Please create a admin/usr for {id}" });
            }
            try
            {
                _context.Admin.Update(admin);
                await _context.SaveChangesAsync();


                return Ok(new { message = $"Admin edit successfully for {id}" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
