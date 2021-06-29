namespace PatientAppMicroservice.DataServiceClients
{
    using ModelClassLibrary;
    using PatientAppMicroservice.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class AppointmentsServiceClient : IAppointmentsServiceClient
    {
        public IHttpClientFactory clientFactory;
        public AppointmentsServiceClient(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
        {

            var request = new HttpRequestMessage(HttpMethod.Get,
            $"http://data-appointments/appointments");
            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return await JsonSerializer.DeserializeAsync<IEnumerable<Appointment>>(responseStream, options);
        }

        public async Task<Appointment> GetAppointmentByIdAsync(Guid id)
        {
            {

                var request = new HttpRequestMessage(HttpMethod.Get,
                $"http://data-appointments/appointments/" + id);
                request.Headers.Add("Accept", "application/json");

                var client = clientFactory.CreateClient();

                var response = await client.SendAsync(request);

                using var responseStream = await response.Content.ReadAsStreamAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                return await JsonSerializer.DeserializeAsync<Appointment>(responseStream, options);
            }
        }

        public async Task<Appointment> UpdateAppointmentAsync(Guid id, AppointmentDto appointment)
        {
            {

                var request = new HttpRequestMessage(HttpMethod.Put,
                $"http://data-appointments/appointments/" + id);

                request.Content = new StringContent(JsonSerializer.Serialize<AppointmentDto>(appointment), Encoding.UTF8, "application/json");
                request.Headers.Add("Accept", "application/json");

                var client = clientFactory.CreateClient();

                var response = await client.SendAsync(request);

                using var responseStream = await response.Content.ReadAsStreamAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                return await JsonSerializer.DeserializeAsync<Appointment>(responseStream, options);
            }
        }

        public async Task<Appointment> PostAppointmentAsync(AppointmentDto appointment)
        {
            {
                
                var request = new HttpRequestMessage(HttpMethod.Post,
                $"http://data-appointments/appointments");

                request.Content = new StringContent(JsonSerializer.Serialize<AppointmentDto>(appointment), Encoding.UTF8, "application/json");
                request.Headers.Add("Accept", "application/json");

                var client = clientFactory.CreateClient();

                var response = await client.SendAsync(request);

                using var responseStream = await response.Content.ReadAsStreamAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                return await JsonSerializer.DeserializeAsync<Appointment>(responseStream, options);
            }
        }

        public async Task<IEnumerable<Appointment>> GetPatientAppointmentsInFrameAsync(Guid id, DateTime from, DateTime to)
        {
            {
                var request = new HttpRequestMessage(HttpMethod.Get,
                $"http://data-appointments/appointments?patient_id=" + id + (from != DateTime.MinValue ? "&from=" + from.ToString("yyyy-MM-ddTHH:mm:ss") : "") + (to != DateTime.MinValue ? "&to=" + to.ToString("yyyy-MM-ddTHH:mm:ss") : ""));
                request.Headers.Add("Accept", "application/json");

                var client = clientFactory.CreateClient();

                var response = await client.SendAsync(request);

                using var responseStream = await response.Content.ReadAsStreamAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                return await JsonSerializer.DeserializeAsync<IEnumerable<Appointment>>(responseStream, options);
            }
        }
        public async Task<IEnumerable<Appointment>> GetDoctorsAppointmentsInFrameAsync(Guid id, DateTime from, DateTime to)
        {
            {

                var request = new HttpRequestMessage(HttpMethod.Get,
                $"http://data-appointments/appointments?doctor_id=" + id + (from != DateTime.MinValue ? "&from=" +from.ToString("yyyy-MM-ddTHH:mm:ss"):"") + (to != DateTime.MinValue ? "&to=" + to.ToString("yyyy-MM-ddTHH:mm:ss") : "")); 
                request.Headers.Add("Accept", "application/json");
            
                var client = clientFactory.CreateClient();

                var response = await client.SendAsync(request);

                using var responseStream = await response.Content.ReadAsStreamAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                return await JsonSerializer.DeserializeAsync<IEnumerable<Appointment>>(responseStream, options);
            }
        }
    }
}

