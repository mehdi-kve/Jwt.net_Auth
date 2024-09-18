using MediatR;
using testAPI.Dtos.Product;

namespace testAPI.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<ProductDto>
    {
        public UpdateProductDto UpdateProductDto { get;}
        public int ProductId { get;}

        public UpdateProductCommand(UpdateProductDto updateProductDto, int productId)
        {
            UpdateProductDto = updateProductDto;
            ProductId = productId;
        }
    }
}
