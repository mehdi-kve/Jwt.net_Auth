using AutoMapper;
using MediatR;
using api.Dtos.Product;
using api.Features.Products.Commands.CreateProduct;
using api.Interfaces;
using api.Models;

namespace api.Features.Products.Commands.UpdateProduct
{
    public class UpdateProdcutHandler : IRequestHandler<UpdateProductCommand, ProductDto>
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public UpdateProdcutHandler(IProductRepository productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepo.UpdateAsync(request.ProductId, request.UpdateProductDto);
            var result = _mapper.Map<ProductDto>(product);
            return (result);
        }
    }
}
