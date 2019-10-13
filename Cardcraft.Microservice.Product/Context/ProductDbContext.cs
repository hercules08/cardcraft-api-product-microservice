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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CardTag>()
                .HasKey(ct => new { ct.CardId, ct.TagId });
            modelBuilder.Entity<CardTag>()
                .HasOne(ct => ct.Card)
                .WithMany(c => c.CardTags)
                .HasForeignKey(ct => ct.CardId);
            modelBuilder.Entity<CardTag>()
                .HasOne(ct => ct.Tag)
                .WithMany(t => t.CardTags)
                .HasForeignKey(ct => ct.TagId);
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Card> Cards { get; set; }

    }
}
