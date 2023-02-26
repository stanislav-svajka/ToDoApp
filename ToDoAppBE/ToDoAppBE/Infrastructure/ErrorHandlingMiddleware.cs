using ToDoAppBE.Exceptions;

namespace ToDoAppBE.Infrastructure;
 

public class ErrorHandlingMiddleware 
{
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
         {
             try
             {
                 await _next(context);
             }
             catch (BadRequestException ex)
             {
                 _logger.LogError(ex, ex.Message);
                 context.Response.StatusCode = StatusCodes.Status400BadRequest;
                 await context.Response.WriteAsJsonAsync(ex.Message);
             }
             catch (ConflictException ex)
             {
                 _logger.LogError(ex, ex.Message);
                 context.Response.StatusCode = StatusCodes.Status409Conflict;
                 await context.Response.WriteAsJsonAsync(ex.Message);
             }
             catch (NotFoundException ex)
             {
                 _logger.LogError(ex, ex.Message);
                 context.Response.StatusCode = StatusCodes.Status404NotFound;
                 await context.Response.WriteAsJsonAsync(ex.Message);
             }
             catch (UnauthorizedException ex)
             {
                 _logger.LogError(ex, ex.Message);
                 context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                 await context.Response.WriteAsJsonAsync(ex.Message);   
             }
             catch (Exception ex)
             {
                 _logger.LogError(ex, ex.Message);
                 context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                 await context.Response.WriteAsJsonAsync(ex.Message);
             }
         }

        
}