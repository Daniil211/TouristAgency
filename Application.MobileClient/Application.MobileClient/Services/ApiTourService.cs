using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Application.MobileClient.Models;

namespace Application.MobileClient.Services
{
    public class ApiTourService : ITourService
    {
        private readonly HttpClient _httpClient;

        public ApiTourService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Tour>> GetTours()
        {
            var response = await _httpClient.GetAsync("Tours");

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Tour>>(responseAsString);
        }

        public async Task<Tour> GetTour(int id)
        {
            var response = await _httpClient.GetAsync($"Tours/{id}");

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Tour>(responseAsString);
        }

        public async Task AddTour(Tour tour)
        {
            var response = await _httpClient.PostAsync("Tours",
                new StringContent(JsonSerializer.Serialize(tour), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteTour(Tour tour)
        {
            var response = await _httpClient.DeleteAsync($"Tours/{tour.TourId}");

            response.EnsureSuccessStatusCode();
        }

        public async Task SaveTour(Tour tour)
        {
            var response = await _httpClient.PutAsync($"Tours?id={tour.TourId}",
                new StringContent(JsonSerializer.Serialize(tour), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
        }
    }
}
