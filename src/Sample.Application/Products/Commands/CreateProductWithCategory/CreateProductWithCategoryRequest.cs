using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Products.Commands.CreateProductWithCategory
{
    public class CreateProductWithCategoryRequest : IRequest<CreateProductWithCategoryResponse>
    {
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
    }
}
