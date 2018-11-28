using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using System;

namespace Filters
{
    public class ResourceFilter : Attribute, IResourceFilter, IAsyncResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            context.HttpContext.Response.WriteAsync($"{GetType().Name} in. \r\n");
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            context.HttpContext.Response.WriteAsync($"{GetType().Name} out. \r\n");
        }
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            await context.HttpContext.Response.WriteAsync($"{GetType().Name} in. \r\n");

            await next();

            await context.HttpContext.Response.WriteAsync($"{GetType().Name} out. \r\n");
        }
    }
}