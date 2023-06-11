using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPractice.Core.Entities
{
    public class PickupLocations:BaseEntity
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public DateTime When { get; set; }
    }
}
