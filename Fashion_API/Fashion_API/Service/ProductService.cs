using Fashion_API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IEnumerable<Products>> get()
        {           
           var data = await _databaseContext.products.ToListAsync();
           if (data == null) return null; 
           return data;
        }

        public object list_pagination(IEnumerable<Products> products, int currentPage, int limit)
        {
            int total_item = products.Count();
            int skip = (currentPage - 1) * limit;
            int total_page = total_item % limit != 0 ? (total_item / limit) + 1 : total_item / limit;

            var product = _databaseContext.products.Skip(skip).Take(limit);

            return new { product, pagination = new{total_item,currentPage,limit,total_page } };
        }
    }
}
