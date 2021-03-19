﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.AppUsers.Queries.LoginAppUser
{
    public class LoginAppUserRequest : IRequest<LoginAppUserResponse>
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
