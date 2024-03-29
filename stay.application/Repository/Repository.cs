﻿using Ardalis.GuardClauses;
using Firebase.Database;
using Firebase.Storage;
using FireSharp.Interfaces;
using FireSharp.Response;
using stay.application.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly IFirebaseClient _firebaseClient;
    protected readonly FirebaseClient _firebaseClientDatabase; 
    protected readonly FirebaseStorage _firebaseClientStorage;


    public Repository(IFirebaseClient firebaseClient, FirebaseClient firebaseClientDatabase, FirebaseStorage firebaseStorage)
    {
        _firebaseClient = firebaseClient;
        _firebaseClientDatabase = firebaseClientDatabase;
        _firebaseClientStorage = firebaseStorage;
    }

    public async Task<T> AddAsync(string path, T entity)
    {
        Guard.Against.NullOrEmpty(path, nameof(path));
        Guard.Against.Null(entity, nameof(entity));

        return (await _firebaseClient.SetAsync(path, entity)).ResultAs<T>();
    }

    public async Task<T> PushAsync(string path, T entity)
    {
        Guard.Against.NullOrEmpty(path, nameof(path));
        Guard.Against.Null(entity, nameof(entity));

        return (await _firebaseClient.PushAsync(path, entity)).ResultAs<T>();
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

    public async Task<List<KeyValuePair<string, T>>> GetAllAsync(string path)
    {
        var temp = await _firebaseClientDatabase.Child(path).OnceAsync<T>();

        return temp.Select(x => new KeyValuePair<string, T>(x.Key, x.Object)).ToList();
    }

    public async Task<string> StoreFile(string name, Stream file)
    {
        return await _firebaseClientStorage
          .Child(name)
          .PutAsync(file);
    }

    public async Task<string> GetFile(string filename)
    {
        return await _firebaseClientStorage
          .Child(filename).GetDownloadUrlAsync();
    }
}