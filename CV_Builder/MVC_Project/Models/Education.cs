using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Final.Models
{
    public class Education
    {
        public Education() { }
        public int Id { get; set; }
        
        public string Degree { get; set; }
        public string University { get; set; }
        public string Grade { get; set; }
        [Range(1970,2023)]
        [DisplayName("Graduation Year")]
        public int GraduationYear { get; set; }
        public bool isDeleted { get; set; }
    }
}
