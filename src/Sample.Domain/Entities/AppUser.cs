﻿using Sample.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain.Entities
{
    public class AppUser : AuditableEntity
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenEndDate { get; set; }
    }
}
