using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using TestAPP.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<AppDBContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDBConnection")));
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<IEmployeeRepository, SQLEmployeeRepository>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<AppDBContext>();


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
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(name: "default", pattern: "{controller=home}/{action=index}/{id?}");


app.Run();
