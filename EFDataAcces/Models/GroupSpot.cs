using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAcces.Models
{
    public class GroupSpot
    {
        public int Id { get; set; }
        public Group Group { get; set; }
        public Spot Spot { get; set; }
    }
}
