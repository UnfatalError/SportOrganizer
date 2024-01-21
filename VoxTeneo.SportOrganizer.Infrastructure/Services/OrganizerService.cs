using Newtonsoft.Json;
using System.Net.Http.Json;
using VoxTeneo.SportOrganizer.Application.DTO;
using VoxTeneo.SportOrganizer.Application.Interfaces;

namespace VoxTeneo.SportOrganizer.Infrastructure.Services
{
    public class OrganizerService : IOrganizerService
    {
        private readonly HttpClient _httpClient;

        public OrganizerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<OrganizerApiResponse<Organizer>> GetOrganizers(string url = null)
        {
            var path = url ?? "/api/v1/organizers";
            var response = await _httpClient.GetAsync(path);

            return await GetResponseContentIfSuccess<OrganizerApiResponse<Organizer>>(response);
        }

        public async Task<Organizer> GetOrganizer(int id)
        {
            var path = $"/api/v1/organizers/{id}";
            var response = await _httpClient.GetAsync(path);

            return await GetResponseContentIfSuccess<Organizer>(response);
        }

        public async Task<Organizer> CreateOrganizer(Organizer organizer)
        {
            var content = JsonContent.Create(organizer);
            var response = await _httpClient.PostAsync("/api/v1/organizers", content);

            return await GetResponseContentIfSuccess<Organizer>(response);
        }

        public async Task<SportEvent> GetSportEvent(int id)
        {
            var response = await _httpClient.GetAsync($"/api/v1/sport-events/{id}");

            return await GetResponseContentIfSuccess<SportEvent>(response);
        }

        public async Task<OrganizerApiResponse<SportEvent>> GetSportEventsByOrganizer(int organizerId)
        {
            var response = await _httpClient.GetAsync($"/api/v1/sport-events?organizerId={organizerId}");

            return await GetResponseContentIfSuccess<OrganizerApiResponse<SportEvent>>(response);
        }

        public async Task<SportEvent> CreateSportEvent(SportEvent sportEvent)
        {
            var content = JsonContent.Create(sportEvent);
            var response = await _httpClient.PostAsync("/api/v1/sport-events", content);

            return await GetResponseContentIfSuccess<SportEvent>(response);
        }

        public async Task<SportEvent> UpdateSportEvent(SportEvent sportEvent)
        {
            var content = JsonContent.Create(sportEvent);
            var response = await _httpClient.PutAsync($"/api/v1/sport-events/{sportEvent.Id}", content);

            return await GetResponseContentIfSuccess<SportEvent>(response);
        }

        public async Task DeleteSportEvent(int sportEventId)
        {
            var response = await _httpClient.DeleteAsync($"/api/v1/sport-events/{sportEventId}");

            response.EnsureSuccessStatusCode();
        }

        private async Task<T> GetResponseContentIfSuccess<T>(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(responseContent);
            return result;
        }
    }
}