using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPractice.Core.Entities
{
    public class Requests:BaseEntity
    {
        public bool IsApprove { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
