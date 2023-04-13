using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Final.Models
{
    public class Comment
    {

        public int Id { get; set; }

        [MinLength(1)]
        public string Text { get; set; }
        
        public DateTime Date { get; set; }
        [DisplayName("Username")]
        public string username{ get; set; }

      // public virtual User {get; set;} 
        [ForeignKey("CvTemplate")]
        public int TemplateId { get; set; }
        public string image { get; set; }
        public virtual CvTemplate CvTemplate { get; set; }
        public bool isDeleted { get; set; }




    }
}