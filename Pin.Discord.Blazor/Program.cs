using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Pin.Discord.Blazor.Components;
using Pin.Discord.Blazor.Hubs;
using Pin.Discord.Core.Data;
using Pin.Discord.Core.Interfaces;
using Pin.Discord.Core.Services;

namespace Pin.Discord.Blazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDatabase")));
            builder.Services.AddSignalR();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();
            builder.Services.AddAuthorization();
            builder.Services.AddScoped<AuthenticationStateProvider, Auth>();
            builder.Services.AddScoped<IUserService, UserService>();

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
            app.UseAntiforgery();
            app.MapHub<ChatHub>("/chathub");
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();
       
            app.Run();
        }
    }
}
