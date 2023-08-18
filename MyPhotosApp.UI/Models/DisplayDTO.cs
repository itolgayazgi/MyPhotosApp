using System.Reflection.Metadata;

namespace MyPhotosApp.UI.Models
{
    public class DisplayDTO : Base
    {
        public string Description { get; set; }
        public string Tags { get; set; }
        public string Base64String { get; set; }
        public string ContentType { get; set; }
    }
}
