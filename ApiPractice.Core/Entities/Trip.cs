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
    }
}
