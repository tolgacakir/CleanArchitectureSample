using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.Products.Commands.CreateProduct;
using Sample.Application.Products.Commands.CreateProductWithCategory;
using Sample.Application.Products.Queries.GetAllProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpPost]
        public async Task<CreateProductWithCategoryResponse> CreateWithCategory([FromBody] CreateProductWithCategoryRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost]
        public async Task<CreateProductResponse> Create([FromBody] CreateProductRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet]
        public async Task<List<GetAllProductsResponse>> GetAllProducts()
        {
            return await _mediator.Send(new GetAllProductsRequest());
        }
    }
}
