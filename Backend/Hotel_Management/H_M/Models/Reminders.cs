using System.ComponentModel.DataAnnotations;

namespace H_M.Models
{
    public class Reminders
    {
        [Key]
        public int Id { get; set; }
        public DateTime DayReported { get; set; }
        public string? Category { get; set; }
        public string? MaintenanceType { get; set; }
        public string? Priority { get; set; }
        public string? ReportedBy { get; set; }
        public string? Description { get; set; }
    }

}
