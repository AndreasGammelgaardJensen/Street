using System;
using System.Collections.Generic;
using System.Text;

namespace Street.Models
{
    public class GroupDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public List<UserDTO> Users { get; set; }
        public List<SpotDTO> Spots { get; set; }
        public bool IsPublic { get; set; }
    }
}
