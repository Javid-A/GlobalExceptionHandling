using GlobalExceptionHandling.Filters;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options=>options.Filters.Add<ExceptionHandlingAttribute>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseExceptionHandler(error =>
//{
//    error.Run(async context =>
//    {
//        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
//        context.Response.ContentType = "application/json";

//        var contextFeatures = context.Features.Get<IExceptionHandlerFeature>();
//        if(contextFeatures is not null)
//        {
//            await context.Response.WriteAsync(contextFeatures.Error.Message);
//        }
//    });
//});

//app.UseMiddleware<GlobalExceptionHandling.Middlewares.ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


//https://www.rfc-editor.org/rfc/rfc7807