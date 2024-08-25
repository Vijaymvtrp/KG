namespace H_M.Models
{
    public class TransactionByRoom
    {

        public int BookingId { get; set; }
        public string Room { get; set; }
        public string RoomType { get; set; }
        public string UserName  { get; set; }
        public string MobileNumber { get; set; }

        public DateTime Date { get; set; }

        public int Amount { get; set; }
        public string Status { get; set; }
        public string PaymentMode { get; set; }
    }
}
