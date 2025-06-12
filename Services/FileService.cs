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
    public class FileService
    {
        private readonly HttpClient _httpClient;
        private readonly String _baseUrl;
        private readonly ILocalStorageService _localStorage;


        public FileService(HttpClient httpClient, IOptions<ApiSettings> options, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _baseUrl = options.Value.BaseUrl;
            _localStorage = localStorage;
        }

        public async Task<List<FileDto>> GetByFolder(int folderId)
        {
            await Utils.InjectToken(_localStorage, _httpClient);
            return await _httpClient.GetFromJsonAsync<List<FileDto>>($"{_baseUrl}/api/File/folder/{folderId}") ?? [];
        }
        public async Task<FileDto?> GetById(int id)
        {
            await Utils.InjectToken(_localStorage, _httpClient);
            return await _httpClient.GetFromJsonAsync<FileDto>($"{_baseUrl}/api/File/{id}");
        }

        public async Task<bool> Create(FileFormModel file)
        {
            await Utils.InjectToken(_localStorage, _httpClient);
            Console.WriteLine(file);

            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/File", file);

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

        public async Task Update(int id, FileEditModel file)
        {
            await Utils.InjectToken(_localStorage, _httpClient);
            await _httpClient.PutAsJsonAsync($"{_baseUrl}/api/File/{id}", file);
        }

        public async Task Delete(int id)
        {
            await Utils.InjectToken(_localStorage, _httpClient);
            await _httpClient.DeleteAsync($"{_baseUrl}/api/File/{id}");
        }
    }
}