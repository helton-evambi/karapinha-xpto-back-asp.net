using KarapinhaModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaDAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=MyConnection")
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<BookingModel> Bookings { get; set; }
        public DbSet<BookingServiceModel> BookingServices { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<ProfessionalModel> Professionals { get; set;}
        public DbSet<ProfessionalTimeModel> professionalTimes { get; set; }
        public DbSet<ServiceModel> Services { get; set; }
        public DbSet<TimeModel> Times { get; set; }
        public DbSet<UserModel> Users { get; set; }
    }
}
