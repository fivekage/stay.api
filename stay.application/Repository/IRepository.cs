using FireSharp.Response;

namespace stay.application.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<FirebaseResponse> GetAsync(string path);

        Task<T> AddAsync(string path, T entity);

        Task<T> PushAsync(string path, T entity);

        Task<FirebaseResponse> UpdateAsync(string path, T entity);

        Task<FirebaseResponse> DeleteAsync(string path);

        Task<string> StoreFile(string name, Stream file);

        Task<string> GetFile(string filename);
    }
}