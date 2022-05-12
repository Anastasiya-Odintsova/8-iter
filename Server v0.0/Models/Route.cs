using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0.Models
{
    public class Route
    {
        public int RouteId { get; set; }
        public string Name { get; set; }
        public uint Distance { get; set; }
        public uint NumberOfDaysOnTheRoad { get; set; }
        public List<WorkDone> WorkDones { get; set; }
    }
}
