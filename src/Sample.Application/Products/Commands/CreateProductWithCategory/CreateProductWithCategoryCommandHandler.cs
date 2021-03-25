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

namespace Sample.Application.Products.Commands.CreateProductWithCategory
{
    public class CreateProductWithCategoryCommandHandler : IRequestHandler<CreateProductWithCategoryRequest, CreateProductWithCategoryResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CreateProductWithCategoryCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateProductWithCategoryResponse> Handle(CreateProductWithCategoryRequest request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            var category = _mapper.Map<Category>(request);

            using var transaction = await _context.BeginTransactionAsync();
            try
            {
                _context.Categories.Add(category);
                await _context.SaveChangesAsync(cancellationToken);

                product.CategoryId = category.Id;
                product.Category = category;
                _context.Products.Add(product);
                await _context.SaveChangesAsync(cancellationToken);

                //throw new NotImplementedException();

                await transaction.CommitAsync();
                var response = _mapper.Map<CreateProductWithCategoryResponse>(product);
                return response;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
