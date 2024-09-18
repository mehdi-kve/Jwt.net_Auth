using MediatR;
using testAPI.Dtos.Product;
using testAPI.Helper;

namespace testAPI.Features.Products.Queries.GetAllProducts
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
