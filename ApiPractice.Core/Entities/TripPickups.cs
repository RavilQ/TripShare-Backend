using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPractice.Core.Entities
{
    public class TripPickups:BaseEntity
    {
        public int PickUpId { get; set; }
        public int TripId { get; set; }

        public Trip Trip { get; set; }
        public PickupLocations PickupLocations { get; set; }
    }
}
