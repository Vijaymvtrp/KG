namespace H_M.Models
{
    public class RoomBookings
    {
        public long BookingId { get; set; }
        public string? Room { get; set; }
        public string? RoomType { get; set; }
        public string UserName { get; set; }
        public int GuestAllowed { get; set; }
        public string? Mobile_Number { get; set; }
        public DateTime CheckinDay { get; set; }
        public DateTime CheckoutDay { get; set; }
        public Double TotalAmount { get; set; }

        public string AmountStatus { get; set; }
    }
}
