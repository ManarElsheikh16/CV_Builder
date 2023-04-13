using Final.Models;
using System.ComponentModel.DataAnnotations;

namespace Final.ViewModel
{
    public class ExperienceViewModel
    {
       //Personal Info
        public string Name { get; set; }
        public string Address { get; set; }
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$")]
        public string Email { get; set; }
        [RegularExpression("^01[0125][0-9]{8}$")]
        public string Phone { get; set; }
        public string Photo { get; set; }
        public string JobTitle { get; set; }

        public PersonalInfo PersonalInfos { get; set; }

        //CoverLetter

        public string CoverLetter { get; set; }


        //Skill
        public string SkillName { get; set; }
        [Range(20, 100)]
        public int Level { get; set; }

        public List<Skill> skills { get; set; }

        //Experience
        public string CompanyName { get; set; }
        public string ExperienceJobTitle { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public string? Details { get; set; }

        public List<Experience> experiences { get; set; }
    }
}
