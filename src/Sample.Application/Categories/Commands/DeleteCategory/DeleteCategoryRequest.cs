using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryRequest : IRequest<DeleteCategoryResponse>
    {
        public int Id { get; set; }
    }
}
