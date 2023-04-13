using System.ComponentModel.DataAnnotations;

namespace Final.Models
{
    public class Links
    {
        public Links() { }
        public int Id { get; set; }
    // [RegularExpression ("(?:https?:)?\\/\\/(?:[\\w]+\\.)?linkedin\\.com\\/in\\/(P<permalink>[\\w\\-]+)\\/?")]
        public string Linkedin { get; set; }
    // [RegularExpression("^(http(s?):\\/\\/)?(www\\.)?github\\.([a-z])+\\/([A-Za-z0-9]{1,})+\\/?$")]
        public string GitHub { get; set; }
        public bool isDeleted { get; set; }
    }
}
