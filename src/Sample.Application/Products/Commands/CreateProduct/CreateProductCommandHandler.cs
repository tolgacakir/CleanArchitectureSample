using AutoMapper;
using MediatR;
using Sample.Application.Common.Exceptions;
using Sample.Application.Common.Interfaces;
using Sample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var category = _context.Categories.SingleOrDefault(c => c.Id == request.CategoryId)
                ?? throw new EntityNotFoundException($"Category was not found. {nameof(request.CategoryId)}: {request.CategoryId}");

            var product = _mapper.Map<Product>(request);
            product.Category = category;
            
            
            _context.Products.Add(product);
            await _context.SaveChangesAsync(cancellationToken);
            var response = _mapper.Map<CreateProductResponse>(product);
            return response;
        }
    }
}
