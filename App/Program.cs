using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Servir archivos estáticos desde ../src-modern o wwwroot
app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/health", () => Results.Ok("OK"));

app.Run();

// Ensure root serves wwwroot/index.html if present
// (DefaultFiles and StaticFiles above should handle this, but add explicit fallback)
app.MapGet("/", async context =>
{
	var env = app.Environment;
	var file = System.IO.Path.Combine(env.ContentRootPath, "wwwroot", "index.html");
	if (System.IO.File.Exists(file))
	{
		context.Response.ContentType = "text/html";
		await context.Response.SendFileAsync(file);
	}
	else
	{
		context.Response.StatusCode = 404;
	}
});
