using System.ComponentModel.DataAnnotations;

namespace H_M.Models
{
    public class Bookings
    {
        [Key]
        public long BookingId { get; set; }
        public int RoomId { get; set; }
        public int Floor { get; set; }

        public string? Room { get; set; }
        public string? RoomType { get; set; }
        public int GuestAllowed { get; set; }
        public string? UserName { get; set; }
        public string? MobileNumber { get; set; }
        public DateTime CheckinDay { get; set; }
        public DateTime CheckoutDay { get;set; }
        public int Days { get; set; }
        public Double RoomPrice { get; set; }
        public Double TotalAmount { get; set; }
        public string? AmountStatus { get; set; }

        public Double AdvanceRemaining { get; set; }
        public string AvailableStatus { get; set; }
    }
}