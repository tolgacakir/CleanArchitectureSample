using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.Categories.Commands.CreateCategory;
using Sample.Application.Categories.Queries.GetAllCategories;
using Sample.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Sample.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<CreateCategoryResponse> Create([FromBody] CreateCategoryRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet]
        public async Task<IEnumerable<GetAllCategoriesResponse>> GetAll()
        {
            return await _mediator.Send(new GetAllCategoriesRequest());
        }
    }
}