using MediatR;
using System.ComponentModel.DataAnnotations;
using api.Dtos.Product;
using api.Models;

namespace api.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<ProductDto>
    {
        public CreateProductDto ProductDto { get;}
        public string AppUserId { get;}

        public CreateProductCommand(CreateProductDto productDto, string appUserId)
        {
            ProductDto = productDto;
            AppUserId = appUserId;
        }

    }
}
