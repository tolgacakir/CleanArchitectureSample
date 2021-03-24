using MediatR;
using Microsoft.EntityFrameworkCore;
using Sample.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.AppUsers.Queries.LoginWithRefreshToken
{
    public class LoginWithRefreshTokenQueryHandler : IRequestHandler<LoginWithRefreshTokenRequest, LoginWithRefreshTokenResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly ITokenService _tokenService;
        private readonly IDateTimeService _dateTimeService;
        public LoginWithRefreshTokenQueryHandler(IApplicationDbContext context, ITokenService tokenService, IDateTimeService dateTimeService)
        {
            _context = context;
            _tokenService = tokenService;
            _dateTimeService = dateTimeService;
        }

        public async Task<LoginWithRefreshTokenResponse> Handle(LoginWithRefreshTokenRequest request, CancellationToken cancellationToken)
        {
            //TODO: @LoginWithRefreshToken. Aşağıdaki sorguya birkaç şart daha eklenebilir.
            var user = await _context.AppUsers.FirstOrDefaultAsync(user => user.RefreshToken == request.RefreshToken);
            if (user?.RefreshTokenEndDate > _dateTimeService.Now)
            {
                var token = _tokenService.CreateAccessToken(30);

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenEndDate = token.Expiration.AddSeconds(300);
                return new LoginWithRefreshTokenResponse
                {
                    Token = token
                };
            }
            else
            {
                return null;
            }
        }
    }
}
