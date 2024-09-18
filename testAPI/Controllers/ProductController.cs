using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testAPI.Data;
using testAPI.Dtos.Product;
using testAPI.Extensions;
using testAPI.Features.Products.Commands.CreateProduct;
using testAPI.Features.Products.Commands.DeleteProduct;
using testAPI.Features.Products.Commands.UpdateProduct;
using testAPI.Features.Products.Queries.GetAllProducts;
using testAPI.Features.Products.Queries.GetProductById;
using testAPI.Helper;
using testAPI.Interfaces;
using testAPI.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace testAPI.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMediator _mediator;

        public ProductController(ApplicationDBContext context,
        UserManager<AppUser> userManager, IMediator mediator)
        {
            _context = context;
            _userManager = userManager;
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var productQuery = new GetAllProductsQuery(query);
            var result = await _mediator.Send(productQuery);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var productQuery = new GetProductByIdQuery(id);
            var result = await _mediator.Send(productQuery);
            if (result == null)
                return BadRequest("Nothing Found");

            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            var productQuery = new CreateProductCommand(productDto, appUser.Id);
            var result = await _mediator.Send(productQuery);

            return Ok(result);
        }

        [HttpPut("{id:int}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductDto updateProductDto)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
                return BadRequest("Nothing Found");

            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            if (product.AppUserId != appUser.Id)
                return StatusCode(401, "Access Denied");

            var productQuery = new UpdateProductCommand(updateProductDto, id);
            var result = await _mediator.Send(productQuery);

            return Ok(result);
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

            var productQuery = new DeleteProductCommand(id);
            var result = await _mediator.Send(productQuery);
            return NoContent();
        }
    }
}
