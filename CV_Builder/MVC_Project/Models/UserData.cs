using System.ComponentModel;
using System.Runtime.Serialization;

namespace Final.Models
{
    public class UserData
    {
        public int Id { get; set; }
        public PersonalInfo PersonalInfo { get; set; } = new PersonalInfo() { };
        [DisplayName("Cover Letter")]
        public string CoverLetter { get; set; }
        
        public virtual List<Skill> Skill { get; set; } =new List<Skill>() { new Skill() { }, new Skill() { }, new Skill() { }, new Skill() { }, new Skill() { }, new Skill() { } };
        public virtual List<Experience> Experiences { get; set; }= new List<Experience>() {new Experience() { },new Experience() { },new Experience() { }  };
        public virtual List<Project> Projects { get; set; }= new List<Project>() {new Project() { },new Project() { },new Project() { }};
        public virtual Links Links { get; set; } = new Links() { };
        public List<CvTemplate> templates { get; set; } = new List<CvTemplate>() { };
        public bool isDeleted { get; set; }
    }
}
