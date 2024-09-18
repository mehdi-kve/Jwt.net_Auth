using MediatR;
using System.ComponentModel.DataAnnotations;
using testAPI.Dtos.Product;
using testAPI.Models;

namespace testAPI.Features.Products.Commands.CreateProduct
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
