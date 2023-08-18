using MyPhotosApp.Data.Contexts;
using MyPhotosApp.Core.IRepos;
using MyPhotosApp.Domain.Entities;

namespace MyPhotosApp.Data.Repositories
{
    public class CategoryReadRepository : ReadRepository<Domain.Entities.Category>, ICategoryReadRepository
    {
        public CategoryReadRepository(MyPhotosDbContext context) : base(context)
        {

        }
    }
}
