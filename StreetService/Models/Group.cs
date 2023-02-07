using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace StreetService.Models
{
    public class Group
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public bool IsPublic { get; set; }

        public List<User> Users { get; set; }
        public List<Spot> Spots { get; set; }


    }
}
