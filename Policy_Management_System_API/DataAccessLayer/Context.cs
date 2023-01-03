using Microsoft.EntityFrameworkCore;


namespace Policy_Management_System_API
{
    public class Context : DbContext
    {
        public Context() { }
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Coverage>? coverage { get; set; }
        public DbSet<PolicyType>? policytype { get; set; }
        public DbSet<HouseDetail>? housedetail { get; set; }
        public DbSet<VehicleDetail>? vehicledetail { get; set; }
        public DbSet<Policy>? policy { get; set; }

    }
}