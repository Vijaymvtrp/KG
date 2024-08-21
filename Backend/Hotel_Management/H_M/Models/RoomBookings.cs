namespace H_M.Models
{
    public class RoomBookings
    {
        
        public int Floor { get; set; }
        public int GuestAllowed { get; set; }
        public int RoomId { get; set; }
        public long BookingId { get; set; }
        public string? Room { get; set; }
        public string? RoomType { get; set; }
        public string? Mobile_Number { get; set; }
    }
}
