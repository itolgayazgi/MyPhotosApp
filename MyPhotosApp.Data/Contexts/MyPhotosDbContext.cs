using Microsoft.EntityFrameworkCore;
using MyPhotosApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotosApp.Data.Contexts
{
    public class MyPhotosDbContext : DbContext
    {
        public MyPhotosDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Category>  Categories { get; set; } 
    }
}
