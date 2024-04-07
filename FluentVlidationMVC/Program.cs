using FluentValidation;
using FluentValidation.AspNetCore;
using FluentVlidationMVC.FluentValidators;
using FluentVlidationMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FluentVlidationMVC;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        //builder.Services.AddSingleton<IValidator<Customer>, CustomerValidator>(); 1. YOL
        builder.Services.AddControllersWithViews().AddFluentValidation(options =>
        {
            options.RegisterValidatorsFromAssemblyContaining<Program>();
        });
        builder.Services.AddDbContext<FluentValidationContext>(options =>
        {
            options.UseSqlServer(builder.Configuration["ConStr"]);
        });

        builder.Services.Configure<ApiBehaviorOptions>(options =>
        {
	        options.SuppressModelStateInvalidFilter = true;
        });

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

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
