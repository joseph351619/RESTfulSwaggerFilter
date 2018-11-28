using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace Filters
{
    public class AuthorizationFilter : IAsyncAuthorizationFilter, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            context.HttpContext.Response.WriteAsync($"{GetType().Name} in. \r\n");
        }        
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            await context.HttpContext.Response.WriteAsync($"{GetType().Name} in. \r\n");
        }
    }
}