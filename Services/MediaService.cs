using System.Net.Http.Headers;
using Blazored.LocalStorage;
using BlazorSuperApp.Dtos;
using BlazorSuperApp.Helpers;
using BlazorSuperApp.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Options;

namespace BlazorSuperApp.Services
{
    public class MediaService(HttpClient httpClient, IOptions<ApiSettings> options, ILocalStorageService localStorage)
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly String _baseUrl = options.Value.BaseUrl;

        private readonly ILocalStorageService _localStorage = localStorage;

        public async Task<List<MediaDto>> GetAll()
        {
            await Utils.InjectToken(_localStorage, _httpClient);
            return await _httpClient.GetFromJsonAsync<List<MediaDto>>($"{_baseUrl}/api/Media") ?? [];
        }
        public async Task<MediaDto?> GetById(int id)
        {
            await Utils.InjectToken(_localStorage, _httpClient);
            return await _httpClient.GetFromJsonAsync<MediaDto>($"{_baseUrl}/api/Media/{id}");
        }

        public async Task<bool> Create(MediaFormModel media, IBrowserFile file)
        {
            await Utils.InjectToken(_localStorage, _httpClient);

            var content = new MultipartFormDataContent{
                {new StringContent(media.Name), "Name"},
                {new StringContent(media.Status.ToString()), "Status"},
                {new StringContent(media.GroupID.ToString()), "GroupId"}
            };

            if (!string.IsNullOrWhiteSpace(media.Type))
            {
                content.Add(new StringContent(media.Type), "Type");
            }

            var fileContent = new StreamContent(file.OpenReadStream(maxAllowedSize: 10_000_000));
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

            // Ajout de l'image dans le content
            content.Add(fileContent, "File", file.Name);

            Console.WriteLine(content);

            var response = await _httpClient.PostAsync($"{_baseUrl}/api/Media", content);

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

        public async Task Update(int id, MediaEditModel media, IBrowserFile? file)
        {
            await Utils.InjectToken(_localStorage, _httpClient);

            var content = new MultipartFormDataContent{
                {new StringContent(media.Id.ToString()), "Id"},
                {new StringContent(media.Name), "Name"},
                {new StringContent(media.Status.ToString()), "Status"},
                {new StringContent(media.GroupID.ToString()), "GroupId"}
            };

            if (!string.IsNullOrWhiteSpace(media.Type))
            {
                content.Add(new StringContent(media.Type), "Type");
            }

            if (file != null)
            {
                var fileContent = new StreamContent(file.OpenReadStream(maxAllowedSize: 10_000_000));
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

                // Ajout de l'image dans le content
                content.Add(fileContent, "File", file.Name);
            }


            var response = await _httpClient.PutAsync($"{_baseUrl}/api/Media/{id}", content);
            if (!response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Erreur {response.StatusCode} : {message}");
            }
        }

        public async Task Delete(int id)
        {
            await Utils.InjectToken(_localStorage, _httpClient);
            await _httpClient.DeleteAsync($"{_baseUrl}/api/Media/{id}");
        }
    }
}