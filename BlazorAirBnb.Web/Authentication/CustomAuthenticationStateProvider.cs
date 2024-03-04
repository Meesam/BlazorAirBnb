﻿using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;

namespace BlazorAirBnb.Web.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {

        private readonly ProtectedSessionStorage _sessionStorage;
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

        public CustomAuthenticationStateProvider(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var userSessionStorageResult = await _sessionStorage.GetAsync<UserSession>("UserSession");
                var userSession = userSessionStorageResult.Success ? userSessionStorageResult.Value : null;
                if (userSession is null)
                {
                    return await Task.FromResult(new AuthenticationState(_anonymous));
                }
                var claimPrinciple = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                   new Claim(ClaimTypes.Name, userSession.UserName),
                   new Claim(ClaimTypes.Role, userSession.Role),

                }, "CustomAuth"
                     ));
                return await Task.FromResult(new AuthenticationState(claimPrinciple));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAuthenticationState(UserSession userSession)
        {
            ClaimsPrincipal claimsPrincipal;

            if (userSession is not null)
            {
                await _sessionStorage.SetAsync("UserSession", userSession);
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                   new Claim(ClaimTypes.Name, userSession.UserName),
                   new Claim(ClaimTypes.Role, userSession.Role),
                }));
            }
            else
            {
                await _sessionStorage.DeleteAsync("UserSession");
                claimsPrincipal = _anonymous;
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }
    }
}
