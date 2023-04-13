using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Final.ViewModel
{
    public class RegisterationViewModel
    {
        [DisplayName("UserName")]
        [Required]
        public string UserNAme { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public string Email { get; set; }

        public IFormFile image { get; set; }
        [DisplayName("Upload Your Image Again")]
        public IFormFile Images { get; set; }


    }
}
