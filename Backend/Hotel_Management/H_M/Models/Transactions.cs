using System.ComponentModel.DataAnnotations.Schema;

namespace H_M.Models
{
    public class Transactions
    {
        public int Id { get; set; }

        public string? TransactionId { get; set; }
        public Double Amount { get; set; }

        public DateTime AmountPaidDate { get; set; }
        public string? Status { get; set; }
        public string? PaymentMode { get; set; }
        public string AvailableStatus { get; set; }
    }
}
