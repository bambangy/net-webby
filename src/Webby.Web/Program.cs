using Microsoft.AspNetCore.Mvc.Razor;
using Webby.Core.Interfaces.Services;
using Webby.Infrastructure;
using Webby.Web.Infrastructure.Theming;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWebbyInfrastructure(builder.Configuration);
builder.Services.AddScoped<IThemeService, ThemeService>();

builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    options.ViewLocationExpanders.Add(new ThemeViewLocationExpander());
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
