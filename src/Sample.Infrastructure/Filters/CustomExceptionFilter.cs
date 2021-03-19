using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Sample.Application.Common.Exceptions;

namespace Sample.Infrastructure.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        //TODO: @CustomExceptionFilter await edilmeyen async metot
        public async override Task OnExceptionAsync(ExceptionContext context)
        {
            int statusCode = (int)HttpStatusCode.InternalServerError;
            if (context.Exception is EntityNotFoundException)
                statusCode = (int)HttpStatusCode.NotFound;

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = statusCode;
            context.Result = new JsonResult(new
            {
                error = new[] { context.Exception.Message },
                source = context.Exception.Source
            });
        }

    }
}
