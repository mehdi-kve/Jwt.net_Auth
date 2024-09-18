using MediatR;
using testAPI.Dtos.Product;

namespace testAPI.Features.Products.Commands.DeleteProduct
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
