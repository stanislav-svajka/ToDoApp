namespace ToDoAppBE.Infrastructure.Interface;

public interface IMiddleware
{
    Task InvokeAsync(HttpContext context);
}   