using MediatR;
using api.Dtos.Product;

namespace api.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<ProductDto>
    {
        public int ProductId { get; }

        public DeleteProductCommand(int productId)
        {
            ProductId = productId;
        }
    }
}
