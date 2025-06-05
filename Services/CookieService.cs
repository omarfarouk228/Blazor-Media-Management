using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSuperApp.Services
{
    public class CookieService(IHttpContextAccessor httpContextAccessor)
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public void SetCookie(string key, string value)
        {
            var options = new CookieOptions
            {
                Expires = DateTime.Now.AddHours(3),
                HttpOnly = true,
                SameSite = SameSiteMode.Strict
            };

            var response = _httpContextAccessor.HttpContext?.Response;
            if (response?.HasStarted == false)
            {
                response.Cookies.Append(key, value, options);
            }

        }
        public string? GetCookie(string key)
        {
            return _httpContextAccessor.HttpContext?.Request.Cookies[key];
        }

        public void DeleteCookie(string key)
        {
            _httpContextAccessor.HttpContext?.Response.Cookies.Delete(key);
        }

    }
}