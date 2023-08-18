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
        public byte[] Bytes { get; set; }
        public string Tags { get; set; }
        public string ContentType { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }

    }
}
