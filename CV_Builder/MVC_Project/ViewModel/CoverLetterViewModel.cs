using Final.Models;
using System.ComponentModel.DataAnnotations;

namespace Final.ViewModel
{
    public class CoverLetterViewModel
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

     
    //Cover Letter
        public string CoverLetter { get; set; }

        /*public PersonalInfo PersonalInfos { get; set;}*/
    }
}
