using GreenBears.VideoTuts.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenBears.VideoTuts.Infrastructure.Data
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext():base("name=DatabaseContext")
        {
                
        }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Video> Videos { get; set; }
    }
}
