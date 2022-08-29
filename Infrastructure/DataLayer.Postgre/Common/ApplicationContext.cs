using Domain.Asset;
using Domain.Common;
using Domain.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Postgre.Common
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Asset>? Assets { get; set; }
        public DbSet<User>? Users { get; set; }
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
            modelBuilder.Entity<User>().HasQueryFilter(c => c.DeletedDate == null);
            modelBuilder.Entity<Asset>().HasQueryFilter(c => c.DeletedDate == null);
            base.OnModelCreating(modelBuilder);
        }
    }
}
