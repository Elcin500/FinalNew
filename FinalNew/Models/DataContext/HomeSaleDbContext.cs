using FinalHomeSale.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalHomeSale.Models.DataContext
{
    public class HomeSaleDbContext : DbContext
    {
        public HomeSaleDbContext(DbContextOptions options)
         : base(options)
        {
        }

        public DbSet<Home> Homes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<HomeImage> HomeImages { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Metro> Metros { get; set; }
        public DbSet<AppInfo> AppInfos { get; set; }
        public DbSet<Comment> Comments { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Home>(e =>
            {
                e.Property(h => h.CreatedDate)
                //.HasDefaultValue(DateTime.Now)
                .HasDefaultValueSql("dateadd(HOUR,4,getutcdate())")
                ;
            });


            modelBuilder.Entity<Agent>(e =>
            {
                e.Property(a => a.CreatedDate)
                //.HasDefaultValue(DateTime.Now)
                .HasDefaultValueSql("dateadd(HOUR,4,getutcdate())")
                ;
            });
        }
    }
}
