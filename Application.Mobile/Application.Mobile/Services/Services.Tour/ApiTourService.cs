using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using XamWebApiClient.Models;

namespace Application.Mobile.Services.Services.Tour
{
    public class ApiTourService : ITourService
    {
        private readonly HttpClient _httpClient;

        public ApiTourService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            var response = await _httpClient.GetAsync("Tours");

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Book>>(responseAsString);
        }

        public async Task<Book> GetBook(int id)
        {
            var response = await _httpClient.GetAsync($"Tours/{id}");

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Book>(responseAsString);
        }

        public async Task AddBook(Book book)
        {
            var response = await _httpClient.PostAsync("Tours",
                new StringContent(JsonSerializer.Serialize(book), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteBook(Book book)
        {
            var response = await _httpClient.DeleteAsync($"Tours/{book.TourId}");

            response.EnsureSuccessStatusCode();
        }

        public async Task SaveBook(Book book)
        {
            var response = await _httpClient.PutAsync($"Tours?id={book.TourId}",
                new StringContent(JsonSerializer.Serialize(book), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
        }
    }
}
