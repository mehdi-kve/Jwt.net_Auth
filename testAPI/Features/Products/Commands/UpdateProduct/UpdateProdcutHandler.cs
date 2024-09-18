using AutoMapper;
using MediatR;
using testAPI.Dtos.Product;
using testAPI.Features.Products.Commands.CreateProduct;
using testAPI.Interfaces;
using testAPI.Models;

namespace testAPI.Features.Products.Commands.UpdateProduct
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
