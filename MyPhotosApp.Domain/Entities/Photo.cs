using MyPhotosApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotosApp.Domain.Entities
{
    public class Photo : BaseEntity
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public byte[] Bytes { get; set; }
        public int Size { get; set; }

        public virtual User User { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
