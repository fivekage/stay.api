using Ardalis.GuardClauses;
using FireSharp.Interfaces;
using FireSharp.Response;
using stay.application.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly IFirebaseClient _firebaseClient;

    public Repository(IFirebaseClient firebaseClient)
    {
        _firebaseClient = firebaseClient;
    }

    public async Task<T> AddAsync(string path, T entity)
    {
        Guard.Against.NullOrEmpty(path, nameof(path));
        Guard.Against.Null(entity, nameof(entity));

        return (await _firebaseClient.SetAsync(path, entity)).ResultAs<T>();
    }

    public async Task<FirebaseResponse> DeleteAsync(string path)
    {
        Guard.Against.NullOrEmpty(path, nameof(path));

        FirebaseResponse response = await _firebaseClient.DeleteAsync(path); //Deletes todos collection
        return response;
    }

    public async Task<FirebaseResponse> GetAsync(string path)
    {
        Guard.Against.NullOrEmpty(path, nameof(path));

        FirebaseResponse response = await _firebaseClient.GetAsync(path);
        return response;
    }

    public async Task<FirebaseResponse> UpdateAsync(string path, T entity)
    {
        Guard.Against.NullOrEmpty(path, nameof(path));
        FirebaseResponse response = await _firebaseClient.UpdateAsync(path, entity);
        return response;
    }
}