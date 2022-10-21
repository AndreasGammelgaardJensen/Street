using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAcces.Models
{
    public class Spot
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public User Creator { get; set; }
        public long Created { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
