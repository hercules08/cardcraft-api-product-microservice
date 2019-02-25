using Cardcraft.Microservice.Product.Model;
using Microsoft.EntityFrameworkCore;
using Card = Cardcraft.Microservice.Product.Model.Card;

namespace Cardcraft.Microservice.Product.Context
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options):base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Card> Cards { get; set; }
    }
}
