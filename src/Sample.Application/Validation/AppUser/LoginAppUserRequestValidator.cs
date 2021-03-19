using FluentValidation;
using Sample.Application.AppUsers.Queries.LoginAppUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Validation.AppUser
{
    public class LoginAppUserRequestValidator : AbstractValidator<LoginAppUserRequest>
    {
    }
}
