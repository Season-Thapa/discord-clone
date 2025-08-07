using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pin.Discord.Core.Services
{
    public class Auth : AuthenticationStateProvider
    {
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Auth(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var user = _httpContextAccessor.HttpContext?.User;

            if (user?.Identity != null && user.Identity.IsAuthenticated)
                return Task.FromResult(new AuthenticationState(user));

            return Task.FromResult(new AuthenticationState(_anonymous));
        }

        public void NotifyAuthenticationStateChanged(ClaimsPrincipal user)
        {
            var authState = Task.FromResult(new AuthenticationState(user));
            NotifyAuthenticationStateChanged(authState);
        }
    }
}
