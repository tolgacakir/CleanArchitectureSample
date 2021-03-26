using AutoMapper;
using MediatR;
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
    public class GetAllProductsQueryHandler :IRequestHandler<GetAllProductsRequest,List<GetAllProductsResponse>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetAllProductsResponse>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
        {
            var products = await _context.Products
                .OrderBy(p=>p.Created)
                .Take(100)
                .Include(p=>p.Category)
                .ToListAsync();
            return _mapper.Map<List<GetAllProductsResponse>>(products);
        }
    }
}
