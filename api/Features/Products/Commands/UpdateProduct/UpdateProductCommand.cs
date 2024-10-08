﻿using MediatR;
using api.Dtos.Product;

namespace api.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<ProductDto>
    {
        public UpdateProductDto UpdateProductDto { get;}
        public int ProductId { get;}

        public UpdateProductCommand(UpdateProductDto updateProductDto, int productId)
        {
            UpdateProductDto = updateProductDto;
            ProductId = productId;
        }
    }
}
