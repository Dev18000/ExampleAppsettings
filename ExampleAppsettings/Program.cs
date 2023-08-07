using ExampleAppsettings.AppSettings;
using ExampleAppsettings.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var webAppOptions = new WebApplicationOptions()
{
    Args = args,

#if DEBUG
    EnvironmentName = Environments.Development,
#else
    EnvironmentName = Environments.Production,
#endif
};

var builder = WebApplication.CreateBuilder(webAppOptions);

builder.Configuration.GetSection(ApplicationServicesSettings.MySettings).Bind(ApplicationServicesSettings.MyClassValue);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

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
