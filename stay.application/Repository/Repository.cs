using Ardalis.GuardClauses;
using FireSharp;
using FireSharp.Response;
using stay.application.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly FirebaseClient _firebaseClient;
    public Repository(FirebaseClient firebaseClient)
    {
        _firebaseClient = firebaseClient;
    }
    public async Task<PushResponse> AddAsync(string path, T entity)
    {
        Guard.Against.NullOrEmpty(path, nameof(path));
        Guard.Against.Null(entity, nameof(entity));

        PushResponse response = await _firebaseClient.PushAsync(path, entity);
        return response;
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