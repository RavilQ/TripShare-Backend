using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPractice.Core.Entities
{
    public class Driver:BaseEntity
    {
        public string CarImage { get; set; }
        public string CarNumer { get; set; }
        public string SelfPhoto { get; set; }
        public int Raiting { get; set; }
        public string Review { get; set; }
        public string AppUserId { get; set; }

        public AppUser AppUser { get; set; }
    }
}
