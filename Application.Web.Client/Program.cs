using Application.Authorize.Utils;
using Application.Web.Client;
using Application.Web.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAuthorizationCore(options => options.AddAppPolicies());

builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddScoped<IClientAuthenticationService, ClientAuthenticationService>();
builder.Services.AddScoped<HttpService>();

builder.Services.AddScoped(x =>
{

    Uri apiUrl;
    if (builder.HostEnvironment.IsDevelopment())
    {
        apiUrl = new Uri(builder.Configuration["localAPIUrl"]);
    }
    else
    {
        apiUrl = new Uri(builder.Configuration["siteAPIUrl"]);
    }

    return new HttpClient() { BaseAddress = apiUrl };
});

//await builder.Build().RunAsync();
