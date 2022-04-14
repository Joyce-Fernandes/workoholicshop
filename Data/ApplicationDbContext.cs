using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using workoholicshop.Models;

namespace workoholicshop.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<workoholicshop.Models.User> User { get; set; }

        public DbSet<workoholicshop.Models.Product> Product { get; set; }

        public DbSet<workoholicshop.Models.Photo> Photo { get; set; }

        public DbSet<workoholicshop.Models.Order> Order { get; set; }

        public DbSet<workoholicshop.Models.Coupon> Coupon { get; set; }

        public DbSet<workoholicshop.Models.Category> Category { get; set; }

        public DbSet<workoholicshop.Models.Cart> Cart { get; set; }
    }
}
