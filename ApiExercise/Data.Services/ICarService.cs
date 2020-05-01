namespace ApiExercise.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ApiExercise.Data.Models;

    public interface ICarService
    {
        IEnumerable<Car> All();

        IEnumerable<Car> All(int id);

        Task AddAsync(Car car);

        Task Edit(Car car);

        Task Delete(int id);
    }
}
