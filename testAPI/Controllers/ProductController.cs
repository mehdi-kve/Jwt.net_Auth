using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testAPI.Data;
using testAPI.Models;

namespace testAPI.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ProductController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Products.ToListAsync());
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
                return BadRequest("Nothing Found");
            return Ok(product);
        }
        
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }

        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Product product)
        {
            var productModel = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (productModel == null)
                return BadRequest("Nothing Found");

            productModel.Id = id;
            productModel.Name = product.Name;
            productModel.ProduceDate = product.ProduceDate;
            productModel.ManufactureEmail = product.ManufactureEmail;
            productModel.ManufacturePhone = product.ManufacturePhone;
            productModel.IsAvailable = product.IsAvailable;

            await _context.SaveChangesAsync();
            return Ok(productModel);
        }

        [HttpPost]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
                return BadRequest("Nothing Found");

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }
    }
}
