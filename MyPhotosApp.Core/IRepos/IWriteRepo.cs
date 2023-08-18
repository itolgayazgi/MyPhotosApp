using MyPhotosApp.Domain.Base;
using MyPhotosApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotosApp.Core.IRepos
{
    public interface IWriteRepo<T> : IRepo<T> where T : BaseEntity
    {
        //Select functions - AsNoTrack for dont manipulate
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> entities);
        bool Remove(T entity);
        bool RemoveRange(List<T> entities);
        Task<bool> RemoveAsync(string id);
        bool Update(T entity);
        Task<int> SaveAsync();
    }
}
