using Microsoft.EntityFrameworkCore;
using Sample.Application.Common.Exceptions;
using Sample.Application.Common.Interfaces;
using Sample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Products.Queries.GetProductWithFilter
{
    public class GetProductWithFilterQueryHandler
    {
        private readonly IApplicationDbContext _context;

        public GetProductWithFilterQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GetProductWithFilterResponse> GetProductWithFilter(GetProductWithFilterRequest request)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(f => f.Name.Contains(request.Word) 
                    && f.UnitPrice >= request.MinPrice 
                    && f.UnitPrice <= request.MaxPrice
                    && f.CategoryId == request.CategoryId);

            return new GetProductWithFilterResponse
            {
                Name = product.Name,
                Price = product.UnitPrice,
                Stock = product.UnitsInStock,
            }
            ?? throw new NotFoundException(nameof(Product), $"{request.Word}, {request.MinPrice}, {request.MaxPrice}");
        }

    }
}
