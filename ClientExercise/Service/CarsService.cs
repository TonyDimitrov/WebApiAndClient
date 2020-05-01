namespace ClientExercise.Service
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json;
    using System.Threading.Tasks;

    using ClientExercise.Client;
    using ClientExercise.Models;

    public class CarsService : ICarsService
    {
        private readonly IClient client;

        public CarsService(IClient client)
        {
            this.client = client;
        }

        public async Task<IEnumerable<Car>> All(int? id)
        {
            var path = string.Format(Constants.Uri, id?.ToString() ?? string.Empty);

            var uri = new Uri(path);

            var response = await this.client.GetClient().GetAsync(uri);

            var result = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<IEnumerable<Car>>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public IEnumerable<Car> All(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task AddAsync(Car car)
        {
            return null;
        }


        public Task Edit(Car car)
        {
            throw new System.NotImplementedException();
        }

        public async Task Delete(int id)
        {
            var path = string.Format(Constants.Uri, id);

            var uri = new Uri(path);

            await this.client.GetClient().DeleteAsync(uri);
        }
    }
}
