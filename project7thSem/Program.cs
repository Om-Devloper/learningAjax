using ConnectionLibrary.Config;
using ConnectionLibrary.Interface;
using ConnectionLibrary.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Configuration.AddJsonFile("appsettings.json",
        optional: true,
        reloadOnChange: true);


AppSettings.ConnectionStrings = builder.Configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>();




//register single tone 
builder.Services.AddSingleton<IConnectionClass, ConnectionClass>();


//builder.Services.Configure<AppSettings>(
//    builder.Configuration.GetSection("AppSettings"));


// sql connection register
//builder.Services.AddDbContext<AppSettings>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Bulky")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.UseEndpoints(endpoints => { 
//endpoints.MapControllerRoute(name: "Notice",
//                pattern: "action=Index}/{id?}",
//                defaults: new { controller = "Blog", action = "Article" });
//endpoints.MapControllerRoute(name: "default",
//               pattern: "{controller=Home}/{action=Index}/{id?}");});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
