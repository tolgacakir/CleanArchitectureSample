using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Products.Queries.GetProductWithFilter
{
    public class GetProductWithFilterResponse
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }
}
