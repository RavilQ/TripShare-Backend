using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPractice.Core.Entities
{
    public class Trip:BaseEntity
    {
        public string From { get; set; }
        public string To { get; set; }
        public DateTime When { get; set; }
        public int TotalSeats { get; set; } 
        public bool Smooking { get; set; }
        public bool Pets { get; set; }
        public bool Luggage { get; set; }
        public int DriverId { get; set; }

        public Driver Driver { get; set; }
    }
}
