using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace Filters
{
    public class ActionFilter : IActionFilter, IAsyncActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Response.WriteAsync($"{GetType().Name} in. \r\n");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Response.WriteAsync($"{GetType().Name} out. \r\n");
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            await context.HttpContext.Response.WriteAsync($"{GetType().Name} in. \r\n");

            await next();

            await context.HttpContext.Response.WriteAsync($"{GetType().Name} out. \r\n");
        }
    }
}