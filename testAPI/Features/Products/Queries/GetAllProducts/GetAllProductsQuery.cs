using MediatR;
using api.Dtos.Product;
using api.Helper;

namespace api.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>
    {
        public QueryObject query { get;}

        public GetAllProductsQuery(QueryObject query)
        {
            this.query = query;
        }
    }
}
