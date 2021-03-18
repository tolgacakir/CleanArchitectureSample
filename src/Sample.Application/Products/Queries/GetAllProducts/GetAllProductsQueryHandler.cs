using Microsoft.EntityFrameworkCore;
using Sample.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler
    {
        private readonly IApplicationDbContext _context;

        public GetAllProductsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetAllProductsResponse>> GetAllProducts(GetAllProductsRequest request, CancellationToken cancellationToken)
        {
            var response = await _context.Products
                .Select(p => new GetAllProductsResponse
                {
                    Name = p.Name,
                    Price = p.UnitPrice,
                })
                .Take(100)
                .ToListAsync();
            return response;
        }
    }
}
