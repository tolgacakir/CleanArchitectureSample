using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.Products.Commands.CreateProductWithCategory;
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
        public async Task<CreateProductWithCategoryResponse> CreateProductWithCategory([FromBody] CreateProductWithCategoryRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
