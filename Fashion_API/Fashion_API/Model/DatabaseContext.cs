using Fashion_API.Service;
using Microsoft.EntityFrameworkCore;

namespace Fashion_API.Model
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<ProductTypes> productTypes { get; set; }
        public DbSet<Categories> categories { get; set; }
        public DbSet<Products> products { get; set; }
        public DbSet<ProductVariant> productVariants { get; set; }
        public DbSet<ProductGallery> productGalleries { get; set; }
        public DbSet<ProductStock> ProductStocks { get; set; }
        public DbSet<Color> colors { get; set; }
        public DbSet<Size> size { get; set; }

        //data 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            modelBuilder.Entity<ProductTypes>()
                .HasMany(c => c.categories)
                .WithOne(pt => pt.productTypes)
                .HasForeignKey(x => x.productTypeId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);
            //modelBuilder.Entity<Products>()
            //    .HasMany(p => p.productGalleries)
            //    .WithOne(g => g.products)
            //    .HasForeignKey(g => g.imageKey)
            //    .HasPrincipalKey(x=>x.image)
            //    .OnDelete(DeleteBehavior.Cascade)
            //    .IsRequired(true);
            //modelBuilder.Entity<Products>()
            //    .HasOne(p => p.productStock)
            //    .WithOne(s => s.products)
            //    .HasForeignKey<ProductStock>(s=>s.productId);
            modelBuilder.Entity<Categories>()
               .HasMany(p => p.products)
               .WithOne(c => c.categories)
               .HasForeignKey(x => x.categoryId)
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired(true);
            modelBuilder.Entity<Products>()
                .HasMany(v => v.productVariant)
                .WithOne(p => p.products)
                .HasForeignKey(p => p.productId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);
            modelBuilder.Entity<ProductVariant>()
                .HasMany(p => p.productGalleries)
                .WithOne(g => g.productVariant)
                .HasForeignKey(g => g.imageKey)
                .HasPrincipalKey(x => x.imageKey)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);
            modelBuilder.Entity<ProductVariant>()
                .HasOne(s => s.productStock)
                .WithOne(v => v.productVariant)
                .HasForeignKey<ProductStock>(s => s.productVariantId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);
            modelBuilder.Entity<Color>()
                .HasMany(v => v.productVariants)
                .WithOne(c => c.color);
            modelBuilder.Entity<Size>()
                .HasMany(v => v.productVariants)
                .WithOne(c => c.size);
            //SEEDING
            modelBuilder.Entity<ProductTypes>().HasData(
              new ProductTypes { id = 1, name = "Áo",slug = Slugify.VietnamSigns("Áo") },
              new ProductTypes { id = 2, name = "Quần", slug = Slugify.VietnamSigns("Quần") },
              new ProductTypes { id = 3, name = "Nón", slug = Slugify.VietnamSigns("Nón") },
              new ProductTypes { id = 4, name = "Phụ kiện", slug = Slugify.VietnamSigns("Phụ kiện") }
            );
            modelBuilder.Entity<Categories>().HasData(
             new Categories { id = 1, name = "Áo thun", slug = Slugify.VietnamSigns("Áo thun"),productTypeId = 1 },
             new Categories { id = 2, name = "Áo sơ mi", slug = Slugify.VietnamSigns("Áo sơ mi"), productTypeId = 1 },
             new Categories { id = 3, name = "Quần thun", slug = Slugify.VietnamSigns("Quần thun"), productTypeId = 2 },
             new Categories { id = 4, name = "Quần kaki", slug = Slugify.VietnamSigns("Quần kaki"), productTypeId = 2 },
             new Categories { id = 5, name = "Mũ lưỡi trai", slug = Slugify.VietnamSigns("Mũ lưỡi trai"), productTypeId = 3 },
             new Categories { id = 6, name = "Túi xách", slug = Slugify.VietnamSigns("Túi xách"), productTypeId = 4 }
            );
            modelBuilder.Entity<Products>().HasData(
             new Products { id = 1, name = "pÁo thun", slug = Slugify.VietnamSigns("Áo thun"), price = 500000, discount= 5, description="mo ta", categoryId = 1 },
             new Products { id = 2, name = "pÁo sơ mi", slug = Slugify.VietnamSigns("Áo sơ mi"), price = 520000, discount = 0, description = "mo ta", categoryId = 2 },
             new Products { id = 3,  name = "pQuần thun", slug = Slugify.VietnamSigns("Quần thun"), price = 400000, discount = 15, description = "mo ta", categoryId = 3 },
             new Products { id = 4, name = "pQuần kaki", slug = Slugify.VietnamSigns("Quần kaki"), price = 460000, discount = 5, description = "mo ta", categoryId = 4 },
             new Products { id = 5, name = "pMũ lưỡi trai", slug = Slugify.VietnamSigns("Mũ lưỡi trai"), price = 500000, discount = 5, description = "mo ta", categoryId = 5 },
             new Products { id = 6, name = "púi xách", slug = Slugify.VietnamSigns("Túi xách"), price = 500000, discount = 5, description = "mo ta ", categoryId = 6 }
            );

            modelBuilder.Entity<Color>().HasData(
                new Color {id = 1, name = "Đen", hexCode = "#000000" },
                new Color {id = 2, name = "Trắng", hexCode = "#FFFFFF" },
                new Color {id = 3, name = "Xanh Dương", hexCode = "#0000FF" },
                new Color {id = 4, name = "Đỏ", hexCode = "#FF0000" },
                new Color {id = 5, name = "Xanh Lá", hexCode = "#008000" }
            );
            modelBuilder.Entity<Size>().HasData(
                new Size{id = 1,name = "S"},
                new Size{id = 2, name = "M"},
                new Size{id = 3, name = "L" },
                new Size{id = 4, name = "XL" },
                new Size{id = 5, name = "2XL" }
            );
          
        }
    }
}
