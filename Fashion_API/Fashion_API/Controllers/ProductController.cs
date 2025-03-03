using Fashion_API.DTO;
using Fashion_API.Model;
using Fashion_API.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fashion_API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly DatabaseContext _databaseContext;
        public readonly IProductService _productService;
        public ProductController(DatabaseContext databaseContext,IProductService productService)
        {
            this._databaseContext = databaseContext;
            this._productService = productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var product = await _productService.get();
            if (product == null) return Ok();
            //var data = _productService.list_pagination(product, 1, 5);
            return Ok(product);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var product = await _productService.get_id(id);
            if (product == null) return Ok();
            
            return Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult> Post([FromForm]ProductDTO productDTO)
        {
            var product = await _productService.post(productDTO);
            //if (product == null) return Ok("fail");
          
            
            return Ok(product);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromForm]ProductDTO productDTO)
        {
            if (id != productDTO.id) return Ok("Không khớp");
            var isHas = _productService.get_id(id);
            if (isHas == null) return Ok("Không tồn tại");
            
            var product = await _productService.put(productDTO);
            if (product == null) return BadRequest();
            return Ok(product);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var isHas = await _productService.get_id(id);
            if (isHas == null) return Ok("Không khớp");
            var result = await _productService.delete(id);
            if(result == 404)
            {
                return Ok("Lỗi");
            }
            return Ok("Xóa thành công");
        }
    }
}
