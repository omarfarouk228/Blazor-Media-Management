using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSuperApp.Services
{
    public class TokenService
    {
        private string? _accessToken;

        public void StoreToken(string token)
        {
            _accessToken = token;
        }

        public string? GetToken()
        {
            return _accessToken;
        }

        public void ClearToken()
        {
            _accessToken = null;
        }
    }
}