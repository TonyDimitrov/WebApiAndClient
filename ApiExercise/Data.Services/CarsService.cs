namespace ApiExercise.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ApiExercise.Data;
    using ApiExercise.Data.Models;

    public class CarsService : ICarService
    {
        private readonly IEntityIRepository<Car> carRepository;

        public CarsService(IEntityIRepository<Car> carRepository)
        {
            this.carRepository = carRepository;
        }

        public IEnumerable<Car> All()
        {
            return this.carRepository.All()
                 .ToList();
        }

        public IEnumerable<Car> All(int id)
        {
            return this.carRepository.All()
                .Where(c => c.Id == id)
                .ToList();
        }

        public async Task AddAsync(Car car)
        {
            await this.carRepository.AddAsync(car);
            await this.carRepository.SaveChangesAsync();
        }

        public async Task Edit(Car car)
        {
            this.carRepository.Edit(car);
            await this.carRepository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var carToDelete = this.carRepository.All()
                .FirstOrDefault(c => c.Id == id);

            this.carRepository.Delete(carToDelete);
            await this.carRepository.SaveChangesAsync();
        }
    }
}
