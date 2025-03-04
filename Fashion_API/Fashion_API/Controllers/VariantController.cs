using Fashion_API.DTO;
using Fashion_API.Model;
using Fashion_API.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fashion_API.Controllers
{
    [Route("api/variant")]
    [ApiController]
    public class VariantController : ControllerBase
    {
        // GET: api/<VariantController>
        public readonly IVariantService _variantService;
        public readonly DatabaseContext _databaseContext;
        public VariantController (IVariantService variantService,DatabaseContext databaseContext)
        {
            _variantService = variantService;
            _databaseContext = databaseContext;
        }

        [HttpGet]
        //<IEnumerable<ProductVariant>>
        public async Task<ActionResult> get()
        {
            var data = await _databaseContext.product_variant.ToListAsync();
            return Ok(data);
        }

        // GET api/<VariantController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var data = _databaseContext.product_variant.FindAsync(id);
            return Ok(data);
        }

        // POST api/<VariantController>
        [HttpPost]
        public async Task<ActionResult> Post([FromForm]VariantDTO variantDTO)
        {
            var data = await _variantService.post(variantDTO);
            if (data == null) return BadRequest();
            return Ok(data);

        }

        // PUT api/<VariantController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<VariantController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
