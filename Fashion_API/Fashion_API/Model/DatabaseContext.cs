using Microsoft.EntityFrameworkCore;

namespace Fashion_API.Model
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Products> products { get; set; }
        public DbSet<Categories> categories { get; set; }
        public DbSet<ProductTypes> productTypes { get; set; }

        //data 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Categories>()
                .HasMany(p => p.products)
                .WithOne(c => c.categories)
                .HasForeignKey(x => x.category_id)              
                .IsRequired(false);
            modelBuilder.Entity<ProductTypes>()
                .HasMany(c => c.categories)
                .WithOne(pt => pt.productTypes)
                .HasForeignKey(x => x.productType_id)
                .IsRequired(false);
            //SEEDING
                 
        }
    }
}
