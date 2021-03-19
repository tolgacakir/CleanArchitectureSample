using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sample.Application.Common.Exceptions;
using Sample.Application.Common.Interfaces;
using Sample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.Products.Queries.GetProductWithFilter
{
    public class GetProductWithFilterQueryHandler : IRequestHandler<GetProductWithFilterRequest,List<GetProductWithFilterResponse>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetProductWithFilterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetProductWithFilterResponse>> Handle(GetProductWithFilterRequest request, CancellationToken cancellationToken)
        {
            var products = await _context.Products
                .Where(f => f.Name.Contains(request.Word)
                    && f.UnitPrice >= request.MinPrice
                    && f.UnitPrice <= request.MaxPrice
                    && f.CategoryId == request.CategoryId)
                .ToListAsync();
            return _mapper.Map<List<GetProductWithFilterResponse>>(products);
        }
    }
}