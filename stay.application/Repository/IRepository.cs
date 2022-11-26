using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
