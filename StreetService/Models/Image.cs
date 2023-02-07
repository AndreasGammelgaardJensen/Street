using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetService.Models
{
    public class Image
    {
        public Guid Id { get; set; }
        public string RemoteUrl { get; set; }
        public User Creator { get; set; }
        public long Created { get; set; }

    }
}
