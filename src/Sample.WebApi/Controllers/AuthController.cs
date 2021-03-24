using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.AppUsers.Queries;
using Sample.Application.AppUsers.Queries.LoginAppUser;
using Sample.Application.AppUsers.Queries.LoginWithRefreshToken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<LoginAppUserResponse> Login(LoginAppUserRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet]
        public async Task<LoginWithRefreshTokenResponse> LoginWithRefreshToken(LoginWithRefreshTokenRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}