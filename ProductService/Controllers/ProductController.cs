using Microsoft.AspNetCore.Mvc;
using ProductService.Data;
using ProductService.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ProductController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return context.Products.ToList();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return context.Products.Where(s => s.Id == id).FirstOrDefault();
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] Product model)
        {
            try
            {
                context.Products.Add(model);
                context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, model);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
                throw;
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
