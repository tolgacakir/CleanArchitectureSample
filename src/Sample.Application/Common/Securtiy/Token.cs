using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Common.Securtiy
{
    public class Token
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
