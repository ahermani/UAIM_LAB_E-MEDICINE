namespace PatientAppTest
{
    using ModelClassLibrary;
    using PatientAppMicroservice.DataServiceClients;
    using PatientAppMicroservice.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class DoctorsServiceClientTest : IDoctorsServiceClient
    {
        public IHttpClientFactory clientFactory;
        public DoctorsServiceClientTest(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }
        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            {

                var request = new HttpRequestMessage(HttpMethod.Get,
                $"http://localhost:5004/doctors");
                request.Headers.Add("Accept", "application/json");

                var client = clientFactory.CreateClient();

                var response = await client.SendAsync(request);

                using var responseStream = await response.Content.ReadAsStreamAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                return await JsonSerializer.DeserializeAsync<IEnumerable<Doctor>>(responseStream, options);
            }
        }

        public async Task<Doctor> GetDoctorByIdAsync(Guid id)
        {
            {

                var request = new HttpRequestMessage(HttpMethod.Get,
                $"http://localhost:5004/doctors/" + id);
                request.Headers.Add("Accept", "application/json");

                var client = clientFactory.CreateClient();

                var response = await client.SendAsync(request);

                using var responseStream = await response.Content.ReadAsStreamAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                return await JsonSerializer.DeserializeAsync<Doctor>(responseStream, options);
            }
        }
    }
}
