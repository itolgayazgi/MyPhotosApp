using MyPhotosApp.Core.IRepos;
using MyPhotosApp.Data.Contexts;
using MyPhotosApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotosApp.Data.Repositories
{
    public class CategoryWriteRepository : WriteRepository<Domain.Entities.Category>, ICategoryWriteRepository
    {
        public CategoryWriteRepository(MyPhotosDbContext context) : base(context)
        {
        }
    }
}
