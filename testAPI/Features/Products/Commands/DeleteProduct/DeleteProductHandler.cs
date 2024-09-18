using AutoMapper;
using MediatR;
using testAPI.Dtos.Product;
using testAPI.Interfaces;

namespace testAPI.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, ProductDto>
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public DeleteProductHandler(IProductRepository productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepo.DeleteAsync(request.ProductId);
            var result = _mapper.Map<ProductDto>(product);
            return (result);
        }
    }
}
