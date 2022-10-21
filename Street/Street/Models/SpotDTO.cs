using System;
using System.Collections.Generic;
using System.Text;

namespace Street.Models
{
    public class SpotDTO
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public UserDTO Creator { get; set; }
        public string Created { get; set; }
        public string Description { get; set; }
        public List<ImageDTO> Images { get; set; }
        public List<VideoDTO> Videos { get; set; }
    }
}
