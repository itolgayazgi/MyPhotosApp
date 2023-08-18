using MyPhotosApp.Core.IRepos;
using MyPhotosApp.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotosApp.Data.Repositories
{
    public class PhotoWriteRepository : WriteRepository<Domain.Entities.Photo>, IPhotoWriteRepository
    {
        public PhotoWriteRepository(MyPhotosDbContext context) : base(context)
        {

        }
    }
}
