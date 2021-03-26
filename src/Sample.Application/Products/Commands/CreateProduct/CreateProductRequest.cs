using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Products.Commands.CreateProduct
{
    public class CreateProductRequest : IRequest<CreateProductResponse>
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public double UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }
}
