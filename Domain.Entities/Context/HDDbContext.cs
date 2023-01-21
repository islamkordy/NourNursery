using Domain.Entities.Entity;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities.Context
{
    public partial class HDDbContext : DbContext//IdentityDbContext
    {
        private readonly ISeedData _dataInitializer;

        public HDDbContext()
        {
        }

        public HDDbContext(DbContextOptions<HDDbContext> options, ISeedData dataInitializer)
            : base(options)
        {
            _dataInitializer = dataInitializer;
        }
        public virtual DbSet<TBL_User> User { get; set; }
        public virtual DbSet<TBL_About> About { get; set; }
        public virtual DbSet<TBL_ContactUs> ContactUs { get; set; }
        public virtual DbSet<TBL_Faqs> Faqs { get; set; }
        public virtual DbSet<TBL_Sliders> Sliders { get; set; }
        public virtual DbSet<TBL_Category> Category { get; set; }
        public virtual DbSet<TBL_Product> Product { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Seed
            modelBuilder.Entity<TBL_User>().HasData(_dataInitializer.ReturnUserList());
            #endregion
            base.OnModelCreating(modelBuilder);
        }

    }
}
