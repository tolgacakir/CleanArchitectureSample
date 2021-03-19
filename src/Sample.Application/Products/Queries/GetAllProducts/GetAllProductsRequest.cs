using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Products.Queries.GetAllProducts
{
    public class GetAllProductsRequest : IRequest<List<GetAllProductsResponse>>
    {
    }
}
