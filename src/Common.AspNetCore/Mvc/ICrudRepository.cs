using System.Collections.Generic;
using System.Threading.Tasks;

namespace Devpro.Common.AspNetCore.Mvc
{
    public interface ICrudRepository<T>
    {
        Task<T?> FindOneAsync(string id);

        Task<List<T>> FindAllAsync();

        Task<T> CreateAsync(T input);

        Task UpdateAsync(string id, T input);

        Task DeleteAsync(string id);
    }
}
