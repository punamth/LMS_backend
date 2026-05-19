using Microsoft.AspNetCore.Http;

public class FileValidationMiddleware
{
    private readonly RequestDelegate _next;

    public FileValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.HasFormContentType && context.Request.Form.Files.Count > 0)
        {
            foreach (var file in context.Request.Form.Files)
            {
                var path = Path.Combine("Uploads", file.FileName);

                using var stream = new FileStream(path, FileMode.Create);
                await file.CopyToAsync(stream);

                // Attach path to HttpContext for controller to read
                context.Items["UploadedFilePath"] = path;
            }
        }

        await _next(context);
    }
}
