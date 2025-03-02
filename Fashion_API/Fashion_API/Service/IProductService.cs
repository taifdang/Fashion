using Fashion_API.DTO;
using Fashion_API.Model;
using Microsoft.AspNetCore.Mvc;

namespace Fashion_API.Service
{
    public interface IProductService
    {
         Task<IEnumerable<Products>> get();
         object list_pagination(IEnumerable<Products> products,int currentPage,int limit);
         Task<Products> get_id(int id);
         Task<Products> post([FromForm] ProductDTO productDTO);
         Task<Products> put([FromForm] ProductDTO productDTO);
         Task<IEnumerable<Products>> search_string(string keyword);
         Task<IEnumerable<Products>> filter(int category_id,SortTypes sortTypes);
         Task<int> delete(int id);

        
    }
}
