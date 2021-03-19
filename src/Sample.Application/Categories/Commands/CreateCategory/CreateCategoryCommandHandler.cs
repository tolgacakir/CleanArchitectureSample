using AutoMapper;
using MediatR;
using Sample.Application.Common.Interfaces;
using Sample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryRequest,CreateCategoryResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CreateCategoryCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //public async Task<int> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
        //{
        //    var category = _mapper.Map<Category>(request);

        //    await _context.Categories.AddAsync(category);
        //    var result = await _context.SaveChangesAsync(cancellationToken);
        //    return result;
        //}

        public async Task<CreateCategoryResponse> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request);

            await _context.Categories.AddAsync(category);
            var result = await _context.SaveChangesAsync(cancellationToken);
            var response = _mapper.Map<CreateCategoryResponse>(category);
            return (result > 0) ? response : null;
        }
    }
}
