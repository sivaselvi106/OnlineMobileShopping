using System.Data.Entity;
using MobileShopping.Entity;
namespace MobileShopping.Repository
{
    public class MobileDBContext : DbContext
    {
        public DbSet<Account> accounts { get; set; }
        public DbSet<Mobile> mobiles { get; set; }
    }
}