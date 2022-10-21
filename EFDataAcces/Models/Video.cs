using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAcces.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string RemoteUrl { get; set; }
        public User Creator { get; set; }
        public Spot Spot { get; set; }
        public long Created { get; set; }
    }
}
