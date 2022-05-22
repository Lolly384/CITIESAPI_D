using CitiesAPI_D.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddControllers();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(endpoints => {
    endpoints.MapControllers();
});
app.UseDefaultFiles();
app.UseStaticFiles();
app.Run();
