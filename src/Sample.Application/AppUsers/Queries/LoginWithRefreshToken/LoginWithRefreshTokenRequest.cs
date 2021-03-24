using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.AppUsers.Queries.LoginWithRefreshToken
{
    public class LoginWithRefreshTokenRequest : IRequest<LoginWithRefreshTokenResponse>
    {
        public string RefreshToken { get; set; }
    }
}
