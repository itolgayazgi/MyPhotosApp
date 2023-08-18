using Microsoft.EntityFrameworkCore;
using MyPhotosApp.Data.Contexts;
using MyPhotosApp.Domain.Base;
using MyPhotosApp.Core.IRepos;
using System.Linq.Expressions;

namespace MyPhotosApp.Data.Repositories
{
    public class ReadRepository<T> : IReadRepo<T> where T : BaseEntity
    {
        readonly MyPhotosDbContext _context;

        public ReadRepository(MyPhotosDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return query;
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(p => p.Id == int.Parse(id));
        }

        public async  Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(predicate);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool tracking = true)
        {
            var query = Table.Where(predicate);
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }
    }
}
