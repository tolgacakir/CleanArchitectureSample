using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sample.Application.Common.Exceptions;
using Sample.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.AppUsers.Queries.LoginAppUser
{
    public class LoginAppUserQueryHandler : IRequestHandler<LoginAppUserRequest, LoginAppUserResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public LoginAppUserQueryHandler(IApplicationDbContext context, IMapper mapper, ITokenService tokenService)
        {
            _context = context;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<LoginAppUserResponse> Handle(LoginAppUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _context.AppUsers.FirstOrDefaultAsync(u => (u.UserName == request.UsernameOrEmail || u.Email == request.UsernameOrEmail) && u.Password == request.Password);
            if (user == null)
            {
                throw new EntityNotFoundException("Username or Password is wrong.");
            }

            var token = _tokenService.CreateAccessToken(30);
            return new LoginAppUserResponse
            {
                Token = token
            };
        }
    }
}
