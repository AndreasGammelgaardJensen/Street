using Microsoft.EntityFrameworkCore;
using StreetService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetService.DataAccess
{
    public class StreetContext : DbContext
    {
        public StreetContext(DbContextOptions options) : base(options) { }
        public DbSet<Group> Group { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Video> Video { get; set; }
        public DbSet<Spot> Spot { get; set; }
        public DbSet<UserGroup> UserGroup { get; set; }
        public DbSet<GroupSpot> GroupSpot { get; set; }
    }
}
