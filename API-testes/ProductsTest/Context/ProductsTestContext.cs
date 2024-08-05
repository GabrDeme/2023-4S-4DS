using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net;
using ProductsTest.Domains;



namespace ProductsTest.Context
{
    public class ProductsTestContext : DbContext
    {
        public ProductsTestContext()
        {
        }

        public ProductsTestContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Products> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE09-S19\\SQLEXPRESS; Database= ProductsTestServer; User Id=sa; Pwd=Senai@134; TrustServerCertificate= True");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
