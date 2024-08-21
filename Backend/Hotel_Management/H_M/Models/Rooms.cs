using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H_M.Models
{
    public class Rooms
    {
        [Key]
        public int RoomId { get; set; }

        public int Floor { get; set; }

        public string? RoomType { get; set; }
        public int GuestAllowed { get; set; }
        public string? Status { get; set; }
        public Double Room_price { get; set; }
        public Double Tax { get; set; }
        public Double Discount { get; set; }

        public string AvailableStatus { get; set; }
    }
}
