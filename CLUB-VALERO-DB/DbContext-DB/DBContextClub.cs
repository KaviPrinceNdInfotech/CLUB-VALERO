using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLUB_VALERO_DB.Entities;
namespace CLUB_VALERO_DB.DbContext_DB
{
    public class DBContextClub:DbContext
    {
        public DBContextClub() : base("ClubVeleroDB")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DBContextClub>(null);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Member> Members { get; set; }

        public DbSet<Login> Logins { get; set; }
        public DbSet<RoleMaster> Rolemastes { get; set; }

        public DbSet<UserAmc> UserAmcs { get; set; }
        public DbSet<UserEmi> UserEmis { get; set; }
        public DbSet<IndianCity> IndianCities { get; set; }

        public DbSet<IndianFullCityPage> indianFullCityPages { get; set; }
        public DbSet<Asia> Asianames { get; set; }

        public DbSet<AsiaFullCityName> asiaFullCityNames { get; set; }

        public DbSet<Booking> bookings { get; set; }

        public DbSet<PaymentOrder> paymentorders { get; set; }

        public DbSet<UtilityPayment> utilitypayments { get; set; }

        public DbSet<ContactUs> contacts { get; set; }

        public DbSet<Message> messages { get; set; }

        public DbSet<Remark> remarks { get; set; }
    }
}
