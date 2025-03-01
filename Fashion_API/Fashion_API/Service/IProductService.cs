using Fashion_API.Model;
using Microsoft.AspNetCore.Mvc;

namespace Fashion_API.Service
{
    public interface IProductService
    {
        public  Task<IEnumerable<Products>> get();
        public object list_pagination(IEnumerable<Products> products,int currentPage,int limit);
    }
}
