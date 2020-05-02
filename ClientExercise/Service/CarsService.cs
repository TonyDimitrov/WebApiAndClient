namespace ClientExercise.Service
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text.Json;
    using System.Threading.Tasks;
    using System.Web.Http;

    using ClientExercise.Client;
    using ClientExercise.Models;

    public class CarsService : ICarsService
    {
        private readonly IClient client;

        public CarsService(IClient client)
        {
            this.client = client;
        }

        public async Task<IEnumerable<Car>> AllAsync(int? id)
        {
            var path = string.Format(Constants.Uri, id?.ToString() ?? string.Empty);

            var uri = new Uri(path);

            var response = await this.client.GetClient().GetAsync(uri);

            var result = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<IEnumerable<Car>>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task AddAsync(Car car)
        {
            var path = string.Format(Constants.Uri, string.Empty);

            var uri = new Uri(path);

            var content = JsonSerializer.Serialize(car, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var request = new StringContent(content);

            request.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await this.client.GetClient().PostAsync(uri, request);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpResponseException(response);
            }
        }

        public async Task EditAsync(Car car)
        {
            var path = string.Format(Constants.Uri, string.Empty);

            var uri = new Uri(path);

            var content = JsonSerializer.Serialize(car, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var request = new StringContent(content);

            request.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await this.client.GetClient().PutAsync(uri, request);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpResponseException(response);
            }
        }

        public async Task Delete(int id)
        {
            var path = string.Format(Constants.Uri, id);

            var uri = new Uri(path);

            await this.client.GetClient().DeleteAsync(uri);
        }
    }
}
