using BusinessLogisLayer.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeManagement.AuthFilters
{
    public class Logged : Attribute, IMiddleware
    {
        //private readonly IAuthService authService;
        //public Logged(IAuthService authService)
        //{
        //    this.authService = authService;
        //}

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var authService = context.RequestServices.GetRequiredService<IAuthService>();
            var header = context.Request.Headers.Authorization;

            if (header.IsNullOrEmpty())
            {
                context.Response.StatusCode = 401; //Unauthorized
                await context.Response.WriteAsync("No Token Supplide");
                return;
            }
            else
            {
                var token = header.ToString();
                if (token != null && !authService.IsTokenValid(token))
                {
                    context.Response.StatusCode = 401; //Unauthorized
                    await context.Response.WriteAsync("Supplied Token is Invalid");
                    return;
                }
            }
            await next(context);
        }
    }
}
