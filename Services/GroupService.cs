using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using BlazorSuperApp.Dtos;
using BlazorSuperApp.Helpers;
using BlazorSuperApp.Models;
using Microsoft.Extensions.Options;

namespace BlazorSuperApp.Services
{
    public class GroupService
    {
        private readonly HttpClient _httpClient;
        private readonly String _baseUrl;
        private readonly ILocalStorageService _localStorage;


        public GroupService(HttpClient httpClient, IOptions<ApiSettings> options, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _baseUrl = options.Value.BaseUrl;
            _localStorage = localStorage;
        }

        public async Task<List<GroupDto>> GetAll()
        {
            await Utils.InjectToken(_localStorage, _httpClient);
            return await _httpClient.GetFromJsonAsync<List<GroupDto>>($"{_baseUrl}/api/Group") ?? [];
        }
        public async Task<GroupDto?> GetById(int id)
        {
            await Utils.InjectToken(_localStorage, _httpClient);
            return await _httpClient.GetFromJsonAsync<GroupDto>($"{_baseUrl}/api/Group/{id}");
        }

        public async Task<bool> Create(GroupFormModel group)
        {
            await Utils.InjectToken(_localStorage, _httpClient);
            Console.WriteLine(group);

            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/Group", group);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Erreur {response.StatusCode} : {message}");

            }
        }

        public async Task Update(int id, GroupEditModel group)
        {
            await Utils.InjectToken(_localStorage, _httpClient);
            await _httpClient.PutAsJsonAsync($"{_baseUrl}/api/Group/{id}", group);
        }

        public async Task Delete(int id)
        {
            await Utils.InjectToken(_localStorage, _httpClient);
            await _httpClient.DeleteAsync($"{_baseUrl}/api/Group/{id}");
        }
    }
}