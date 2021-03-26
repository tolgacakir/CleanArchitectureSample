using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Products.Queries.GetAllProducts
{
    public class GetAllProductsResponse
    {
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public double UnitPrice { get; set; }
    }
}
