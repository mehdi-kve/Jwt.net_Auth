using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using testAPI.Data;
using testAPI.Dtos.Product;
using testAPI.Features.Products.Queries.GetAllProducts;
using testAPI.Interfaces;
using testAPI.Models;

namespace testAPI.Features.Products.Queries.GetProductById
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
