namespace Devpro.SalesPortal.CrmAdapterWebApi.Repositories
{
    public abstract class CrudRepositoryBase<T> : ICrudRepository<T>
    {
        protected CrudRepositoryBase(ILogger logger, HttpClient client)
        {
            Logger = logger;
            Client = client;
        }
        protected ILogger Logger { get; }

        protected HttpClient Client { get; }

        protected abstract string ResourceName { get; }

        public async Task<T?> FindOneAsync(string id)
        {
            var response = await Client.GetAsync($"/{ResourceName}/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"The response status \"{response.StatusCode}\" is not a success (reason=\"{response.ReasonPhrase}\")");
            }

            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<List<T>> FindAllAsync()
        {
            var response = await Client.GetAsync($"/{ResourceName}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"The response status \"{response.StatusCode}\" is not a success (reason=\"{response.ReasonPhrase}\")");
            }

            return await response.Content.ReadFromJsonAsync<List<T>>() ?? new List<T>();
        }

        public async Task<T> CreateAsync(T input)
        {
            var response = await Client.PostAsJsonAsync($"/{ResourceName}", input);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"The response status \"{response.StatusCode}\" is not a success (reason=\"{response.ReasonPhrase}\")");
            }

            return await response.Content.ReadFromJsonAsync<T>() ?? throw new Exception("Successful creation but no data received in return");
        }

        public async Task UpdateAsync(string id, T input)
        {
            var response = await Client.PutAsJsonAsync($"/{ResourceName}/{id}", input);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"The response status \"{response.StatusCode}\" is not a success (reason=\"{response.ReasonPhrase}\")");
            }
        }

        public async Task DeleteAsync(string id)
        {
            var response = await Client.DeleteAsync($"/{ResourceName}/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"The response status \"{response.StatusCode}\" is not a success (reason=\"{response.ReasonPhrase}\")");
            }
        }
    }
}
