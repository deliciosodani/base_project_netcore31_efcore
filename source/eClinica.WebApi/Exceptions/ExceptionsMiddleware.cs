using eClinica.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace eClinica.WebApi.Exceptions
{
    public class ExceptionsMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionsMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BadRequestException badRequestException)
            {
                context.Response.ContentType = context.Response.ContentType == null ? "application/problem+json" : context.Response.ContentType + ";application/problem+json";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var error = badRequestException.GetJsonDescription();
                await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes(error));
            }
        }
    }
}
