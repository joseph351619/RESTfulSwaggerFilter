using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace Filters
{
    public class ExceptionFilter : IExceptionFilter, IAsyncExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.WriteAsync($"{GetType().Name} in. \r\n");
        }
        public Task OnExceptionAsync(ExceptionContext context)
        {
            context.HttpContext.Response.WriteAsync($"{GetType().Name} in. \r\n");
            return Task.CompletedTask;
        }
    }
}