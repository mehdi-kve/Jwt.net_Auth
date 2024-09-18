using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using testAPI.Data;
using testAPI.Dtos.Product;
using testAPI.Interfaces;
using testAPI.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace testAPI.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDto>
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IMapper mapper,IProductRepository productRepository)
        {
            _productRepo = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request.ProductDto);
            await _productRepo.CreateAsync(product, request.AppUserId);
            var result = _mapper.Map<ProductDto>(product);
            return (result);
        }
    }
}
