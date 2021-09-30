using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectSharp.WebUi.Features.WelcomePage
{
    public class ApiPostService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ApiPostService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<string> GetHolidays(AuthenticationRequest holidaysRequest)
        {
            var result = "";

            var url = string.Format("http://localhost:5000/api/ApplicationUser/{0}",
                holidaysRequest);

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "application/json");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                // result = JsonSerializer.Deserialize<List<HolidayResponseModel>>(stringResponse,
                //     new JsonSerializerOptions() {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            }
            else
            {
                // result = Array.Empty<HolidayResponseModel>().ToList();
            }

            return result;
        }
    }
}