
using Microsoft.EntityFrameworkCore;
using Pin.Discord.Blazor.Components;
using Pin.Discord.Blazor.Hubs;
using Pin.Discord.Core.Data;
using Pin.Discord.Core.Interfaces;
using Pin.Discord.Core.Services;
using Pin.Discord.Core.Services.State;

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

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IMessageService, MessageService>();
            builder.Services.AddScoped<IServerMemberService, ServerMemberService>();
            builder.Services.AddScoped<IChannelService, ChannelService>();
            builder.Services.AddScoped<IServerService, ServerService>();
            builder.Services.AddScoped<UserState>();

            var app = builder.Build();

            // Configure middleware
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAntiforgery();


            app.MapHub<ChatHub>("/chathub");

            app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

            app.Run();

        }
    }
}
