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
        public DbSet<ProductGallery> productGalleries { get; set; }

        //data 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Categories>()
                .HasMany(p => p.products)
                .WithOne(c => c.categories)
                .HasForeignKey(x => x.categoryId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);
            modelBuilder.Entity<ProductTypes>()
                .HasMany(c => c.categories)
                .WithOne(pt => pt.productTypes)
                .HasForeignKey(x => x.productTypeId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);
            //modelBuilder.Entity<ProductGallery>()
            //    .HasOne(p => p.products)
            //    .WithMany(pg => pg.productGalleries)
            //    .HasForeignKey(pg => pg.image_key)
            //    .HasPrincipalKey(p => p.image)
            //    .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Products>()
                .HasMany(p => p.productGalleries)
                .WithOne(g => g.products)
                .HasForeignKey(g => g.productId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);
            //.IsRequired(false);
            //SEEDING


        }
    }
}
