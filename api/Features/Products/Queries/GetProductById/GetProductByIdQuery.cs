using MediatR;
using api.Dtos.Product;

namespace api.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductDto>
    {
        public int id { get;}

        public GetProductByIdQuery(int id)
        {
            this.id = id;
        }
    }
}
