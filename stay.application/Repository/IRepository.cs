using FireSharp.Response;

namespace stay.application.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<FirebaseResponse> GetAsync(string path);

        Task<PushResponse> AddAsync(string path, T entity);

        Task<FirebaseResponse> UpdateAsync(string path, T entity);

        Task<FirebaseResponse> DeleteAsync(string path);
    }
}