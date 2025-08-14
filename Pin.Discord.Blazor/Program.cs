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

            // Add services
            builder.Services.AddRazorComponents().AddInteractiveServerComponents();

            builder.Services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDatabase"))
            );

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/login";
                    options.ExpireTimeSpan = TimeSpan.FromHours(8);
                });

            builder.Services.AddAuthorization();

            builder.Services.AddScoped<AuthenticationStateProvider, Auth>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IMessageService, MessageService>();
            builder.Services.AddScoped<IServerMemberService, ServerMemberService>();
            builder.Services.AddScoped<IChannelService, ChannelService>();
            builder.Services.AddScoped<IServerService, ServerService>();

            var app = builder.Build();

            // Configure middleware
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            // Require authenticated users for chat hub
            app.MapHub<ChatHub>("/chathub").RequireAuthorization();

            app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
            app.UseAntiforgery();

            app.Run();

        }
    }
}
