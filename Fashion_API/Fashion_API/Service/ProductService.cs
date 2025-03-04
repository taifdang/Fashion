using Fashion_API.DTO;
using Fashion_API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Fashion_API.Service
{
    public class ProductService : IProductService
    {
        public readonly DatabaseContext _databaseContext;
        //constructor
        public ProductService(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        public async Task<int> delete(int id)
        {
            
            try
            {
                var product = await _databaseContext.products.FindAsync(id);
                if (product == null) return 404;
                _databaseContext.Remove(product);
               await _databaseContext.SaveChangesAsync();
            }
            catch
            {
                return 404;
            }
            return 200;


        }

        public Task<IEnumerable<Products>> filter(int category_id, SortTypes sortTypes)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Products>> get()
        {           
           var data = await _databaseContext.products.ToListAsync();
           if (data == null) return null; 
           return data;
        }

        public async Task<Products> get_id(int id)
        {         
            var product = await _databaseContext.products.FindAsync(id);
            if (product == null) return null;
            return product;
        }

        public object list_pagination(IEnumerable<Products> products, int currentPage, int limit)
        {
            int total_item = products.Count();
            int skip = (currentPage - 1) * limit;
            int total_page = total_item % limit != 0 ? (total_item / limit) + 1 : total_item / limit;

            IQueryable<Products> product = _databaseContext.products.Skip(skip).Take(limit);

            return new { product, pagination = new{total_item,currentPage,limit,total_page } };
        }
     

        public async Task<Products> post([FromForm] ProductDTO productDTO)
        {

            //Guid key = Guid.NewGuid();
            try
            {
                var product = new Products
                {
                    name = productDTO.name,
                    //slug = Slugify.VietnamSigns(productDTO.name),
                    //image = key,
                    //price = productDTO.price,
                    category_id = productDTO.category_id,
                    //productGalleries = new List<ProductGallery>() { new ProductGallery { imageKey = key } }
                };
                _databaseContext.products.Add(product);
                await _databaseContext.SaveChangesAsync();
                return product;
            }
            catch
            {
                return null;
            }
            //using (var transaction = _databaseContext.Database.BeginTransaction() )
            //{
            //    try
            //    {
            //        var product = new Products
            //        {
            //            name = productDTO.name,
            //            slug = Slugify.VietnamSigns(productDTO.name),
            //            image = key,
            //            price = productDTO.price,
            //            categoryId = productDTO.category_id,
            //            //productGalleries = new List<ProductGallery>() { new ProductGallery { imageKey = key } }
            //        };
            //        _databaseContext.products.Add(product);
            //        await _databaseContext.SaveChangesAsync();
            //        transaction.Commit();
            //        var gallery =new ProductGallery { imageKey = key };
            //        _databaseContext.productGalleries.Add(gallery);
            //        await _databaseContext.SaveChangesAsync();

            //        return product;
            //    }
            //    catch
            //    {
            //        transaction.Rollback();
            //        return null;
            //    }
            //}

        }

        public async Task<Products> put([FromForm] ProductDTO productDTO)
        {
            var product = await _databaseContext.products.FirstOrDefaultAsync(p => p.id == productDTO.id);
            if (product == null) return null;
           
           
            try
            {
                product.id = productDTO.id;
                product.name = productDTO.name;
                //product.slug = Slugify.VietnamSigns(productDTO.name);
                //product.price = productDTO.price;
                product.description = productDTO.description;
                product.category_id = productDTO.category_id;

                await _databaseContext.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
            return product;
            
        }

        public Task<IEnumerable<Products>> search_string(string keyword)
        {
            throw new NotImplementedException();
        }

       
    }
}
