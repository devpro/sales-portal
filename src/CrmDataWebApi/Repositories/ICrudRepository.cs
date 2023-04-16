namespace Devpro.SalesPortal.CrmDataWebApi.Repositories
{
    public interface ICrudRepository<T, U> where U : IMongoDbEntity
    {
        Task<T> FindOneAsync(string id);

        Task<List<T>> FindAllAsync();

        Task<T> CreateAsync(T input);

        Task<long> UpdateAsync(string id, T input);

        Task<long> DeleteAsync(string id);
    }
}
