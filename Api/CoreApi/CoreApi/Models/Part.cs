using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApi.Models
{
    public class Part
    {
        public int PartId { get; set; }
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Spec { get; set; }
        public Part()
        {

        }
    }
}
