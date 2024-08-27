using System.Text.Json;

namespace H_M.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public string type { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Double MobileNumber { get; set; }
        public string Company { get; set; }
        public string Gst { get; set; }
        public JsonElement Address { get; set; }
    }
}
