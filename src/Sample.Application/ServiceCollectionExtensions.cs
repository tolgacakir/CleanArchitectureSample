using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Sample.Application.Categories.Queries.GetAllCategories;
using Sample.Application.Categories.Commands.CreateCategory;
using Sample.Application.AppUsers.Queries;
using Sample.Application.AppUsers.Queries.LoginAppUser;

namespace Sample.Application
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
