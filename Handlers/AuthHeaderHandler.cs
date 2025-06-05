using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using BlazorSuperApp.Services;

namespace BlazorSuperApp.Handlers
{
    public class AuthHeaderHandler(TokenService tokenService) : DelegatingHandler
    {
        private readonly TokenService _tokenService = tokenService;


        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            /*Console.WriteLine("Test");
            // if (_httpContextAccessor.HttpContext?.Response.HasStarted == false)
            // {
            Console.WriteLine("Test2");
            var token = _tokenService.GetToken();
            Console.WriteLine("Token : " + token);

            if (!string.IsNullOrWhiteSpace(token))
            {
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                Console.WriteLine($"Authorization: Bearer {token}");
            }*/
            //  }
            return await base.SendAsync(request, cancellationToken);
        }
    }
}