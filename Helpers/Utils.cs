using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.LocalStorage;

namespace BlazorSuperApp.Helpers
{
    public class Utils
    {
        public static async Task InjectToken(ILocalStorageService _localStorage, HttpClient _httpClient)
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");

            if (!string.IsNullOrWhiteSpace(token))
            {
                Console.WriteLine("Token : " + token);
                _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

        }
    }
}