using Application.WebClient;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


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

await builder.Build().RunAsync();
