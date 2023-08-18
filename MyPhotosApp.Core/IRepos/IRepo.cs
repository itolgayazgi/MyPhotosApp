using Microsoft.EntityFrameworkCore;
using MyPhotosApp.Domain.Base;

namespace MyPhotosApp.Core.IRepos
{
    public interface IRepo<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}