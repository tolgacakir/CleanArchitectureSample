using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain.Common
{
    public interface IPassivable
    {
        bool IsActive { get; set; }
    }
}
