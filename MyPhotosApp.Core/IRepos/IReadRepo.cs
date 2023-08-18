using MyPhotosApp.Domain.Base;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotosApp.Core.IRepos
{
    public interface IReadRepo<T> : IRepo<T> where T : BaseEntity
    {
        //Select functions - AsNoTrack for dont manipulate
        IQueryable<T> GetAll(bool tracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, bool tracking = true);
        Task<T> GetByIdAsync(string id, bool tracking = true);
    }
}
