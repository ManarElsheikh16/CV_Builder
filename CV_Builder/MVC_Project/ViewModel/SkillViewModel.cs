using System.ComponentModel.DataAnnotations;

namespace Final.ViewModel
{
    public class SkillViewModel
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


        //CoverLetter
        public string CoverLetter { get; set; }


        //Skill
        public string SkillName { get; set; }
        [Range(20, 100)]
        public int Level { get; set; }
       
    }
}
