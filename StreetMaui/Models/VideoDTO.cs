using System;
using System.Collections.Generic;
using System.Text;

namespace Street.Models
{
    public class VideoDTO
    {
        public Guid Id { get; set; }
        public string RemoteUrl { get; set; }
        public UserDTO Creator { get; set; }
        public long Created { get; set; }
    }
}
