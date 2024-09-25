using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using api.Data;
using api.Dtos.Product;
using api.Features.Products.Queries.GetAllProducts;
using api.Interfaces;
using api.Models;

namespace api.Features.Products.Queries.GetProductById
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;


        public GetProductByIdHandler(ApplicationDBContext context, IMapper mapper,
        UserManager<AppUser> userManager, IProductRepository productRepository)
        {
            _productRepo = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepo.GetByIdAsync(request.id);
            if (product == null)
                return null;
            return(_mapper.Map<ProductDto>(product));

        }
    }
}
