using System.Collections.Generic;

namespace Server_v0._0.Models
{
    public class Driver
    {
        public int DriverId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronomic { get; set; }
        public uint Experience { get; set; }
        public List<Payment> Payments { get; set; }
    }
}
