using H_M.Data;
using H_M.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace H_M.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowAllOrigins")]
    public class GetTransactionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GetTransactionsController(AppDbContext context)
        {

         _context = context; 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transactions>>> GetTransactions()
        {
            var transactions = await _context.Transactions.ToListAsync();

            if (transactions.Count == 0 || transactions == null)
            {
                return Ok(new { message = "There are no transaction still now!" });
            }
            else 
            {
                return Ok(transactions);    
            }
        }

        [HttpPost]

        public async Task<ActionResult<Transactions>> UploadTransaction(Transactions transactions)
        {
            if(transactions == null)
            {
                return BadRequest(new {message = "Invalid transactions data"});
            }
            else
            {
                try
                {
                    _context.Transactions.Add(transactions);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction(nameof(GetTransactions), transactions);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.ToString());
                }
            }
        }

        [HttpPut("id")]

        public async Task<IActionResult> EditTransaction(int id, Transactions transactions)
        {
            if (id != transactions.Id)
            {
                return BadRequest(new { message = $"please create the transaction {id}" });
            }
            try
            {
                _context.Entry(transactions).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return Ok(new { message = $"Transaction edited successfully for {id}" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }

    }
}
