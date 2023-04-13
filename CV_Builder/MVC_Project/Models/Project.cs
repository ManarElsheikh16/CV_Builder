using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Final.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        [DataType (DataType.Date)]
        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }
        public string? Link { get; set; }
        public bool isDeleted { get; set; }

    }
}
