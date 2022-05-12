using System.ComponentModel.DataAnnotations.Schema;

namespace Server_v0._0.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public uint Bonus { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
        public int WorkDoneId { get; set; }
        public WorkDone WorkDone { get; set; }
    }
}
