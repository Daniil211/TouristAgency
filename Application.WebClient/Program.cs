using Application.WebClient;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Application.WebClient.Data;
using Application.WebClient.Data.Authentication;
using Application.WebClient.Data.Repository;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Tewr.Blazor.FileReader;
using Application.Database;
using Microsoft.AspNetCore.Authorization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddDbContext<TourAgencyContext>(options =>
    options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IApplicationDbContext, TourAgencyContext>();
builder.Services.AddScoped<IRepository, SqlGameRepository>();

builder.Services.AddScoped<WebsiteAuthenticator>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<WebsiteAuthenticator>());

builder.Services.AddSingleton<IAuthorizationHandler, AdultRequirementHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, OverAgeRequirementHandler>();
builder.Services.AddSingleton<ICurrentUserService, CurrentUserService>();
builder.Services.AddFileReaderService(options => options.InitializeOnFirstCall = true);
await builder.Build().RunAsync();
