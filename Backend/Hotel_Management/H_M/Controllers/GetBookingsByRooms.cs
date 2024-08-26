using H_M.Data;
using H_M.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using Npgsql;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Cors;

namespace H_M.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowAllOrigins")]
    public class GetBookingsByRooms : ControllerBase
    {

        private readonly AppDbContext _Context;

        private readonly IConfiguration _Configuration;

        public GetBookingsByRooms(AppDbContext context, IConfiguration configuration)
        {
            _Context = context;
            _Configuration = configuration;
        }

        /*[HttpGet("GetRoomBookings")]

        public async Task<IActionResult> GetRoomBookings()
        {
            var query = @"
        SELECT json_agg(row_to_json(t))
        FROM (
            SELECT r.""Room_Id"", r.""Floor"", r.""GuestAllowed"", 
                   b.""RoomId"", b.""BookingId"", b.""Room"", b.""RoomType"", b.""Mobile_Number""
            FROM ""Rooms"" AS r
            INNER JOIN ""Bookings"" AS b
            ON b.""RoomId"" = r.""Room_Id""
        ) t;
    "
            ;

            var connectionString = _Configuration.GetConnectionString("DefaultConnection");
            string jsonResult;

            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new NpgsqlCommand(query, connection))
                {
                    jsonResult = await command.ExecuteScalarAsync() as string;
                }
            }

            return Content(jsonResult, "application/json");
        }
*/
        [HttpGet("GetRoomBookings")]
        public async Task<IActionResult> GetRoomBookings()
        {
            var query = @"
                          SELECT  
	                             b.Booking_Id, 
	                             b.Room, 
	                             b.Room_Type,
	                             b.User_Name,
	                             b.Guest_Allowed,
	                             b.Mobile_Number,
	                             b.Checkin_Day,
	                             b.Checkout_Day,
	                             b.Total_Amount,
	                             b.Amount_Status
                            FROM Rooms AS r
                            INNER JOIN Bookings AS b
                            ON b.Room_Id = r.Room_Id;";

            // Execute the raw SQL query and map the results directly to the RoomBookings model
            var roomBookingsList = await _Context.RoomBookings
                                                 .FromSqlRaw(query)
                                                 .ToListAsync();

            return Ok(roomBookingsList);
        }



    }
}
