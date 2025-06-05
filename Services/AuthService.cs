using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using BlazorSuperApp.Models;
using Microsoft.Extensions.Options;

namespace BlazorSuperApp.Services
{
    public class AuthService(HttpClient httpClient,
    IOptions<ApiSettings> options,
     ILocalStorageService localStorageService,
     CookieService cookieService,
     TokenService tokenService)
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly String _baseUrl = options.Value.BaseUrl;
        private readonly ILocalStorageService _localStorageService = localStorageService;

        private readonly CookieService _cookieService = cookieService;

        private readonly TokenService _tokenService = tokenService;

        public async Task<string?> Login(LoginModel loginModel)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/Auth/login", loginModel);

            if (!response.IsSuccessStatusCode)
                return "Erreur serveur. Veuilez réessayer!";

            var result = await response.Content.ReadFromJsonAsync<AuthResult>();

            if (result is null || !result.IsSuccess || string.IsNullOrWhiteSpace(result.Token))
            {
                return result?.Message ?? "Échec de la connexion";
            }


            await _localStorageService.SetItemAsync("authToken", result.Token);
            await _localStorageService.SetItemAsync("currentUser", result.User);


            return null;
        }

    }
}