using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using System.Linq;

public class ValidationMiddleware<T> where T : class
{
    private readonly RequestDelegate _next;
    private readonly IValidator<T> _validator;

    public ValidationMiddleware(RequestDelegate next, IValidator<T> validator)
    {
        _next = next;
        _validator = validator;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Request.EnableBuffering();
        var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
        context.Request.Body.Position = 0;

        var model = System.Text.Json.JsonSerializer.Deserialize<T>(body);
        
        if (model == null)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(new { error = "Invalid request body" });
            return;
        }

        var result = await _validator.ValidateAsync(model);

        if (!result.IsValid)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            var errors = result.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
            await context.Response.WriteAsJsonAsync(errors);
            return;
        }

        await _next(context);
    }
}
