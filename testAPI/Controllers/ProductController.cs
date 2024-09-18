using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testAPI.Data;
using testAPI.Dtos.Product;
using testAPI.Extensions;
using testAPI.Helper;
using testAPI.Interfaces;
using testAPI.Models;

namespace testAPI.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public ProductController(ApplicationDBContext context, IMapper mapper,
        UserManager<AppUser> userManager, IProductRepository productRepository)
        {
            _context = context;
            _productRepo = productRepository;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var products = await _productRepo.GetAllAsync(query);
            var productDto = products.Select(p => _mapper.Map<ProductDto>(p));
            return Ok(productDto);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            if (product == null)
                return BadRequest("Nothing Found");

            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateProductDto productModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var product = _mapper.Map<Product>(productModel);
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            product.AppUserId = appUser.Id;

            await _productRepo.CreateAsync(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, _mapper.Map<ProductDto>(product));
        }

        [HttpPut("{id:int}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductDto productModel)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
                return BadRequest("Nothing Found");

            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            if (product.AppUserId != appUser.Id)
                return StatusCode(401, "Access Denied");

            product = await _productRepo.UpdateAsync(id, productModel);
            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
                return BadRequest("Nothing Found");

            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            if (product.AppUserId != appUser.Id)
                return StatusCode(401, "Access Denied");

            await _productRepo.DeleteAsync(id);
            return NoContent();
        }
    }
}
