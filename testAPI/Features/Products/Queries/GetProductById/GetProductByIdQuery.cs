using MediatR;
using testAPI.Dtos.Product;

namespace testAPI.Features.Products.Queries.GetProductById
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
