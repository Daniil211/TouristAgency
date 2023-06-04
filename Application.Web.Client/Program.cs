using Application.Database;
using Application.Web.Client.Data;
using Application.Web.Client.Data.Authentication;
using Application.Web.Client.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Tewr.Blazor.FileReader;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TourAgencyContext>(options =>
    options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IApplicationDbContext, TourAgencyContext>();
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<IRepository, SqlRepository>();
builder.Services.AddAntDesign();
builder.Services.AddScoped<WebsiteAuthenticator>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<WebsiteAuthenticator>());
builder.Services.AddAuthorization(config =>
{
    config.AddPolicy("CanBuyAlcohol", policy =>
    {
        policy.AddRequirements(new AdultRequirement());
        policy.RequireClaim("IsPremiumMember", true.ToString());
    });

    config.AddPolicy("OverAge", policy => policy.AddRequirements(new OverAgeRequirement()));
});
builder.Services.AddSingleton<IAuthorizationHandler, AdultRequirementHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, OverAgeRequirementHandler>();
builder.Services.AddSingleton<ICurrentUserService, CurrentUserService>();

//builder.Services.AddSingleton<IRepository, MockRepository>();
//Если у вас не отображает ваши изменения  после создания новой игры
//-то там где мы подключали   в сервисы IRepository, замените AddTransient на AddSingletone ,незачто


//Не стоит так делать, ибо Singleton создаёт один экземпляр сервиса на всех.
//Просто обновите данные в массиве с играми. Не забывайте, что в базу добавляется новая игра, а вот массив, из которого выводим данные 
//сам не обновится. Поэтому делаем повторный запрос на получения всех данных из базы и всё будет отображаться.

//ну мы же "подменяем БД" в реальном кейсе мы бы обращались к ней, и брали от туда все, я
//просто делал все как у вас и у меня не отрисовывало новую игру ,а страничку обновляло, я прошел дебагом и понял что на выходе
//оно получает "5ую" игу  но когда обращаеться к нашей  "БД" то оно не обновляет существующий экземпляр,а делает новый на 4 элемента...
builder.Services.AddFileReaderService(options => options.InitializeOnFirstCall = true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
