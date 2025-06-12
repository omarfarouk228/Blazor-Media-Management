using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using BlazorSuperApp.Dtos;
using BlazorSuperApp.Helpers;
using BlazorSuperApp.Models;
using Microsoft.Extensions.Options;

namespace BlazorSuperApp.Services
{
    public class FolderService
    {
        private readonly HttpClient _httpClient;
        private readonly String _baseUrl;
        private readonly ILocalStorageService _localStorage;


        public FolderService(HttpClient httpClient, IOptions<ApiSettings> options, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _baseUrl = options.Value.BaseUrl;
            _localStorage = localStorage;
        }

        public async Task<List<FolderDto>> GetAll()
        {
            await Utils.InjectToken(_localStorage, _httpClient);
            return await _httpClient.GetFromJsonAsync<List<FolderDto>>($"{_baseUrl}/api/Folder") ?? [];
        }
        public async Task<FolderDto?> GetById(int id)
        {
            await Utils.InjectToken(_localStorage, _httpClient);
            return await _httpClient.GetFromJsonAsync<FolderDto>($"{_baseUrl}/api/Folder/{id}");
        }

        public async Task<List<FolderDto>> GetChildrens(int id)
        {
            await Utils.InjectToken(_localStorage, _httpClient);
            return await _httpClient.GetFromJsonAsync<List<FolderDto>>($"{_baseUrl}/api/Folder/children/{id}") ?? [];
        }

        public async Task<bool> HasFiles(int id)
        {
            await Utils.InjectToken(_localStorage, _httpClient);
            return await _httpClient.GetFromJsonAsync<bool>($"{_baseUrl}/api/Folder/hasfile/{id}");
        }

        public async Task<bool> Create(FolderFormModel folder)
        {
            await Utils.InjectToken(_localStorage, _httpClient);
            Console.WriteLine(folder);

            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/Folder", folder);

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

        public async Task Update(int id, FolderEditModel folder)
        {
            await Utils.InjectToken(_localStorage, _httpClient);
            await _httpClient.PutAsJsonAsync($"{_baseUrl}/api/Folder/{id}", folder);
        }

        public async Task Delete(int id)
        {
            await Utils.InjectToken(_localStorage, _httpClient);
            await _httpClient.DeleteAsync($"{_baseUrl}/api/Folder/{id}");
        }
    }
}