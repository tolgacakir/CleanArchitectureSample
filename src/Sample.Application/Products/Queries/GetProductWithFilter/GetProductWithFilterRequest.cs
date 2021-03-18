using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Products.Queries.GetProductWithFilter
{
    public class GetProductWithFilterRequest
    {
        public int CategoryId { get; set; }
        public string Word { get; set; }
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
    }
}
