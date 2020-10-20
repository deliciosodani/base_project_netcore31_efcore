using eClinica.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer;
using System;
using System.Threading.Tasks;

namespace eClinica.WebApi.Exceptions
{
    public class EFExceptionsMiddleware
    {
        private readonly RequestDelegate _next;
        public EFExceptionsMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                if (ex is DbUpdateException dbUpdateEx)
                {
                    if (dbUpdateEx.InnerException != null && dbUpdateEx.InnerException.InnerException != null)
                    {
                        switch (ex.Message)
                        {
                            case "Duplicate entry '%s' for key '%d'": // personalizar mensaje                                
                                throw new BadRequestException(ex.Message);
                            default:
                                throw;
                        }
                        
                        throw;
                    }
                }
                else
                {
                    throw;
                }
            }
        }
    }
}