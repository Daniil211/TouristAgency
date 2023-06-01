using Application.Database;
using Application.WebApi.Services;
using Application.WebApi.Utils;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCustomSwagger();
builder.Services.AddCustomOptions(builder.Configuration);
builder.Services.AddCustomServices();
builder.Services.AddCustomDbContext(builder.Configuration, typeof(Program).Assembly);
builder.Services.AddCustomJwtBearer(builder.Configuration);
builder.Services.AddCustomCors();
builder.Services.AddCustomAntiforgery();


builder.Services.AddDbContext<TourAgencyContext>(options => options.UseSqlServer("DefaultConnection"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializerService>();
    dbInitializer.Initialize();
    dbInitializer.SeedData();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseExceptionHandler(appBuilder =>
{
    appBuilder.Use(async (context, next) =>
    {
        var error = context.Features[typeof(IExceptionHandlerFeature)] as IExceptionHandlerFeature;
        if (error?.Error is SecurityTokenExpiredException)
        {
            context.Response.StatusCode = 401;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(new
            {
                State = 401,
                Msg = "token expired"
            }));
        }
        else if (error?.Error != null)
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(new
            {
                State = 500,
                Msg = error.Error.Message
            }));
        }
        else
        {
            await next();
        }
    });
});

app.UseStatusCodePages();

app.UseCustomSwagger();
app.UseStaticFiles();

app.UseRouting();


app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();



app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("Hello World!");
    });
});

app.MapControllers();

app.Run();
