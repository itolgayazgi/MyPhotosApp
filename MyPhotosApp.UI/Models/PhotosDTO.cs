using System.ComponentModel.DataAnnotations;

namespace MyPhotosApp.UI.Models
{
    public class PhotosDTO : Base
    {
        public string Name { get; set; }
        public string Tags { get; set; }
        public string ContentType { get; set; }
        public byte[] Bytes { get; set; }
        public string Description { get; set; }
        public string Base64String { get; set; }
        public IFormFile File { get; set; }
    }
}
