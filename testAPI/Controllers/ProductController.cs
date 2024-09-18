using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testAPI.Data;
using testAPI.Dtos.Product;
using testAPI.Extensions;
using testAPI.Models;

namespace testAPI.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public ProductController(ApplicationDBContext context, IMapper mapper,
            UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var products = await _context.Products.ToListAsync();
            var productDto = products.Select(p => _mapper.Map<ProductDto>(p));
            return Ok(productDto);
        }

        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
                return BadRequest("Nothing Found");
            return Ok(_mapper.Map<ProductDto>(product));
        }
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateProductDto productModel)
        {
            var product = _mapper.Map<Product>(productModel);
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            product.AppUserId = appUser.Id;
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpPut]
        [Authorize]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductDto productModel)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
                return BadRequest("Nothing Found");

            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            if (product.AppUserId != appUser.Id)
                return StatusCode(401, "Access Denied");

            var updatedProduct = _mapper.Map<Product>(productModel);

            product.Name = updatedProduct.Name;
            product.ProduceDate = updatedProduct.ProduceDate;
            product.IsAvailable = updatedProduct.IsAvailable;

            await _context.SaveChangesAsync();
            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpDelete]
        [Authorize]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
                return BadRequest("Nothing Found");

            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            if (product.AppUserId != appUser.Id)
                return StatusCode(401, "Access Denied");

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return Ok(_mapper.Map<ProductDto>(product));
        }
    }
}
