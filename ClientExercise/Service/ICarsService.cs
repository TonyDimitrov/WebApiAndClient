namespace ClientExercise.Service
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ClientExercise.Models;

    public interface ICarsService
    {
        Task<IEnumerable<Car>> AllAsync(int? id);

        Task AddAsync(Car car);

        Task EditAsync(Car car);

        Task Delete(int id);
    }
}
