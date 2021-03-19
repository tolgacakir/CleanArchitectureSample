using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesRequest : IRequest<List<GetAllCategoriesResponse>>
    {
    }
}
