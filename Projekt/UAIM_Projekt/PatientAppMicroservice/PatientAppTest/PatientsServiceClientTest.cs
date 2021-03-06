namespace PatientAppTest
{
    using ModelClassLibrary;
    using PatientAppMicroservice.DataServiceClients;
    using PatientAppMicroservice.Dtos;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class PatientsServiceClientTest : IPatientsServiceClient
    {
        public IHttpClientFactory clientFactory;
        public PatientsServiceClientTest(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }
        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {

            var request = new HttpRequestMessage(HttpMethod.Get,
            $"http://localhost:5003/patient");
            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return await JsonSerializer.DeserializeAsync<IEnumerable<Patient>>(responseStream, options);
        }
        public async Task<Patient> GetPatientByIdAsync(Guid id)
        {
            {

                var request = new HttpRequestMessage(HttpMethod.Get,
                $"http://localhost:5003/patient/" + id);
                request.Headers.Add("Accept", "application/json");

                var client = clientFactory.CreateClient();

                var response = await client.SendAsync(request);

                using var responseStream = await response.Content.ReadAsStreamAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                return await JsonSerializer.DeserializeAsync<Patient>(responseStream, options);
            }
        }

        public async Task<Patient> UpdatePatientAsync(Guid id, PatientDto patient)
        {
            {

                var request = new HttpRequestMessage(HttpMethod.Put,
                $"http://localhost:5003/patient/" + id);

                request.Content = new StringContent(JsonSerializer.Serialize<PatientDto>(patient), Encoding.UTF8, "application/json");
                request.Headers.Add("Accept", "application/json");

                var client = clientFactory.CreateClient();

                var response = await client.SendAsync(request);

                using var responseStream = await response.Content.ReadAsStreamAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                return await JsonSerializer.DeserializeAsync<Patient>(responseStream, options);
            }
        }
    }
}

