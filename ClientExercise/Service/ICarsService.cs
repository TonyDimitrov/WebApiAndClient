
namespace ClientExercise.Service
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ClientExercise.Models;

    public interface ICarsService
    {
        Task<IEnumerable<Car>> All(int? id);

        Task AddAsync(Car car);

        Task Edit(Car car);

        Task Delete(int id);
    }
}
