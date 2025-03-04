using Fashion_API.DTO;
using Fashion_API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fashion_API.Service
{
    public class VariantService : IVariantService
    {
        private readonly DatabaseContext _databaseContext;
        public VariantService(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }
        public async Task<IEnumerable<ProductVariant>> get()
        {
            var data = await _databaseContext.product_variant.ToListAsync();
            if (data == null) return null;
            return data;
        }

        public async Task<ProductVariant> getId(int id)
        {
           return await _databaseContext.product_variant.FindAsync(id);

        }

        public async Task<ProductVariant> post([FromForm] VariantDTO variantDTO)
        {
            //Guid key = Guid.NewGuid();

            //try
            //{
            //    var data = new ProductVariant
            //    {
            //        productId = variantDTO.productId,
            //        colorId = variantDTO.colorId,
            //        sizeId = variantDTO.sizeId,
            //        imageKey = key,
            //        productGalleries = new List<ProductGallery>() { new ProductGallery { imageKey = key,productId = variantDTO.productId } },
            //        productStock = new ProductStock { productId=variantDTO.productId,quantity = variantDTO.quantity},


            //    };

            //     _databaseContext.product_variant.Add(data);
            //     await _databaseContext.SaveChangesAsync();
            //    return data;
            //}
            //catch
            //{
            //    return null;
            //}
            return null;
        }
    }
}
