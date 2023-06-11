using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPractice.Core.Entities
{
    public class Reviews:BaseEntity
    {
        public string AppUserId { get; set; }

        //cycle - a dusurdu

        //public int TripId { get; set; }

        public AppUser AppUser { get; set; }
        //public Trip Trip { get; set; }
    }
}
