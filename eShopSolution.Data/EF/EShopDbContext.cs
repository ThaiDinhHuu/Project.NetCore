using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShopSolution.Data.Extentions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using eShopSolution.Data.Entities;

namespace eShopSolution.Data.EF
{
    public class EShopDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public EShopDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new Configurations.AppConfigConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.ContactConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.CartConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.OrderConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.ProductConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.ProductInCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.ProductImageConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.ProductTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.PromotionConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.SlideConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.LanguageConfiguration());

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);

            modelBuilder.seed();
        }

        public DbSet<Entities.Product> Products { get; set; }
        public DbSet<Entities.Category> Categories { get; set; }
        public DbSet<Entities.Cart> Carts { get; set; }
        public DbSet<Entities.Order> Orders { get; set; }
        public DbSet<Entities.OrderDetail> OrderDetails { get; set; }
        public DbSet<Entities.ProductInCategory> ProductInCategories { get; set; }
        public DbSet<Entities.ProductImage> ProductImages { get; set; }
        public DbSet<Entities.ProductTranslation> ProductTranslations { get; set; }
        public DbSet<Entities.Promotion> Promotions { get; set; }
        public DbSet<Entities.Transaction> Transactions { get; set; }
        public DbSet<Entities.AppUser> AppUsers { get; set; }
        public DbSet<Entities.AppRole> AppRoles { get; set; }
        public DbSet<Entities.Slide> Slides { get; set; }
        public DbSet<Entities.Language> Languages { get; set; }
        public DbSet<Entities.Contact> Contacts { get; set; }
        public DbSet<Entities.AppConfig> AppConfigs { get; set; }
    }
}
