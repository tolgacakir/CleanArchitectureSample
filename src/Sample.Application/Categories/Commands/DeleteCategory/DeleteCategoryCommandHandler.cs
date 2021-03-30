using AutoMapper;
using MediatR;
using Sample.Application.Common.Exceptions;
using Sample.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryRequest, DeleteCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public DeleteCategoryCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<DeleteCategoryResponse> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == request.Id);
            if (category == null)
            {
                throw new EntityNotFoundException();
            }
            else
            {
                category.IsDeleted = true;
                await _context.SaveChangesAsync(cancellationToken);
                return _mapper.Map<DeleteCategoryResponse>(category);
            }
        }
    }
}
