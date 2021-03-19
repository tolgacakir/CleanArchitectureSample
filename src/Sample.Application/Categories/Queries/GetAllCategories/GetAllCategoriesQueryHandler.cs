using Sample.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace Sample.Application.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesRequest,List<GetAllCategoriesResponse>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetAllCategoriesResponse>> Handle(GetAllCategoriesRequest request, CancellationToken cancellationToken)
        {
            var products = await _context.Categories
                .Take(100)
                .ToListAsync();

            return _mapper.Map<List<GetAllCategoriesResponse>>(products);
        }


        //public async Task<IEnumerable<GetAllCategoriesResponse>> Handle(GetAllCategoriesRequest request, CancellationToken cancellationToken)
        //{
        //    var products = await _context.Categories
        //        .Take(100)
        //        .ToListAsync();

        //    return _mapper.Map<IEnumerable<GetAllCategoriesResponse>>(products);
        //}
    }
}
