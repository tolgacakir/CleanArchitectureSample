﻿using Sample.Application.Common.Securtiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Common.Interfaces
{
    public interface ITokenService
    {
        Token GetEmptyToken();
        Token CreateAccessToken(int durationInSeconds);
        string CreateRefreshToken();
    }
}
