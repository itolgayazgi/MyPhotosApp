using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotosApp.Domain.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public Guid RowId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedById { get; set; }
        public Guid CreatedByRowId { get; set; }

    }
}
