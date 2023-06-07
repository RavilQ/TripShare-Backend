using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPractice.Core.Entities
{
    public class City : BaseEntity
    {
        public string Label { get; set; }
        public string Value { get; set; }
    }
}
