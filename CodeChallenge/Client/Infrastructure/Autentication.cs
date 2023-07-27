using Blazored.SessionStorage;
using CodeChallenge.Domain.Entities.Users;
using CodeChallenge.Shared.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace CodeChallenge.Client.Infrastructure
{
    public class Autentication : AuthenticationStateProvider
    {
        private readonly ISessionStorageService _sessionStorage;

        public Autentication(ISessionStorageService sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public async Task UpdateAutenticacionState(User? userSession)
        {
            ClaimsPrincipal claimsPrincipal;

            if (userSession != null)
            {
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name,userSession.Name),
                    new Claim(ClaimTypes.Email,userSession.Email),
                    new Claim(ClaimTypes.Gender,userSession.Gender.ToString()),
                    new Claim(ClaimTypes.DateOfBirth,userSession.Age.ToString())
                }, "JwtAuth"));

                await _sessionStorage.SaveStorage("sesionUsuario", userSession);
            }
            else
            {
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());
                await _sessionStorage.RemoveItemAsync("sesionUsuario");
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));

        }


        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            var userSession = await _sessionStorage.GetStorage<User>("sesionUsuario");

            if (userSession == null)
                return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));

            var claimPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name,userSession.Name),
                    new Claim(ClaimTypes.Email,userSession.Email),
                    new Claim(ClaimTypes.Gender,userSession.Gender.ToString()),
                    new Claim(ClaimTypes.DateOfBirth,userSession.Age.ToString())
                }, "JwtAuth"));


            return await Task.FromResult(new AuthenticationState(claimPrincipal));

        }
    }
}
