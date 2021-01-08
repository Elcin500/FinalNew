using FinalNew.Models.Entity;
using FinalNew.Models.Entity.Membership;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalNew.Models.DataContext
{
    public class HomeSaleDbContext : IdentityDbContext<AppUser, AppRole, int, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>
    {
        public HomeSaleDbContext(DbContextOptions options)
         : base(options)
        {
        }


        #region Membership
        public DbSet<AppUser> Users { get; set; }
        public DbSet<AppRole> Roles { get; set; }
        public DbSet<AppUserClaim> UserClaims { get; set; }
        public DbSet<AppUserRole> UserRoles { get; set; }
        public DbSet<AppUserLogin> UserLogins { get; set; }
        public DbSet<AppRoleClaim> RoleClaims { get; set; }
        public DbSet<AppUserToken> UserTokens { get; set; }
        #endregion

        public DbSet<Home> Homes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<HomeImage> HomeImages { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Metro> Metros { get; set; }
        public DbSet<AppInfo> AppInfos { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<NMRDistrict> NMRDistricts { get; set; }
        public DbSet<BakuDistrict> BakuDistricts { get; set; }





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

            modelBuilder.Entity<Comment>(e =>
            {
                e.Property(a => a.CreatedDate)
                //.HasDefaultValue(DateTime.Now)
                .HasDefaultValueSql("dateadd(HOUR,4,getutcdate())")
                ;
            });
        }
    }
}
