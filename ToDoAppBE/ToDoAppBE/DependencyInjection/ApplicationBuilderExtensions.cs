using ToDoAppBE.Infrastructure;
using Microsoft.AspNetCore.Builder;

namespace ToDoAppBE.DependencyInjection; 

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ErrorHandlingMiddleware>();
        return app;
    }

}