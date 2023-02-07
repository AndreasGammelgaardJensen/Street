using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetService.Models
{
    public class Spot
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public User Creator { get; set; }
        public DateTime Created { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        public List<Image> Images { get; set; }

        public List<Video> Videos { get; set; }
    }
}
