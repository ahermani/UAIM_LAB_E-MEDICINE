namespace PatientAppMicroservice.DataServiceClients
{
    using ModelClassLibrary;
    using PatientAppMicroservice.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class TreatmentsServiceClient : ITreatmentsServiceClient
    {
        public IHttpClientFactory clientFactory;
        public TreatmentsServiceClient(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }
        public async Task<IEnumerable<TreatmentDto>> GetAllTreatmentsAsync()
        {
            {

                var request = new HttpRequestMessage(HttpMethod.Get,
                $"http://data-treatments/treatments");
                request.Headers.Add("Accept", "application/json");

                var client = clientFactory.CreateClient();

                var response = await client.SendAsync(request);

                using var responseStream = await response.Content.ReadAsStreamAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                return await JsonSerializer.DeserializeAsync<IEnumerable<TreatmentDto>>(responseStream, options);
            }
        }

        public async Task<TreatmentDto> GetTreatmentByIdAsync(Guid id)
        {
            {

                var request = new HttpRequestMessage(HttpMethod.Get,
                $"http://data-treatments/treatments/" + id);
                request.Headers.Add("Accept", "application/json");

                var client = clientFactory.CreateClient();

                var response = await client.SendAsync(request);

                using var responseStream = await response.Content.ReadAsStreamAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                return await JsonSerializer.DeserializeAsync<TreatmentDto>(responseStream, options);
            }
        }
    }
}
