namespace WebApi.Context
{
    using System.Data.Entity;
    using WebApi.Models;

    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("DefaultConnection") { }

        public DbSet<Tech.Company> Company { get; set; }
        public DbSet<Tech.User> Users { get; set; }
        public DbSet<Tech.Order> Order { get; set; }
        public DbSet<Tech.Item> Item { get; set; }
    }
}