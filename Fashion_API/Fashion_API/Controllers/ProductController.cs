using Fashion_API.Model;
using Fashion_API.Service;
using Microsoft.AspNetCore.Mvc;

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
            var data = _productService.list_pagination(product, 1, 5);
            return Ok(data);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
