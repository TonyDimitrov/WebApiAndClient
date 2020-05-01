namespace ApiExercise.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEntityIRepository<T>
         where T : class
    {
        IEnumerable<T> All();

        Task AddAsync(T entity);

        void Edit(T entity);

        void Delete(T entity);

        Task<int> SaveChangesAsync();
    }
}
