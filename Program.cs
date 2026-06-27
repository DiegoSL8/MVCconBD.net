using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVCconBD2.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MVCconBD2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MVCconBD2Context") ?? throw new InvalidOperationException("Connection string 'MVCconBD2Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseStaticFiles();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
