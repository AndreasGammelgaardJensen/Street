using System;
using System.Collections.Generic;
using System.Text;

namespace Street.Models
{
    public class ImageDTO
    {
        public int Id { get; set; }
        public string RemoteUrl { get; set; }
        public UserDTO Creator { get; set; }
        public long Created { get; set; }
    }
}
