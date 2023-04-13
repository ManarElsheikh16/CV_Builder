using Final.Models;
using Final.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;

namespace Final.Controllers
{
    public class UserDataController : Controller
    {
      
        Context context = new Context();

        UserData UserData = new UserData();


        [HttpGet]
        [Authorize]
        public IActionResult PersonalInfo()
        {
          
            
            return View();
        }


        [HttpPost]
        [Authorize]
        public IActionResult CoverLetter(PersonalViewModel ps )
        {

            
                string FileName = ps.Photo.FileName;



                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/clients", FileName);


                ps.Photo.CopyTo(new FileStream(imagePath, FileMode.Create));

                UserData.PersonalInfo.Address = ps.Address;
                UserData.PersonalInfo.Name = ps.Name;
                UserData.PersonalInfo.Age = ps.Age;
                UserData.PersonalInfo.Email = ps.Email;
                UserData.PersonalInfo.JobTitle = ps.JobTitle;
                UserData.PersonalInfo.Languages = ps.Languages;
                UserData.PersonalInfo.Phone = ps.Phone;
                UserData.PersonalInfo.Photo = ps.Photo.FileName;




                return View(UserData);
           
           
              
            
         
        }


        [HttpPost]
        [Authorize]
        public IActionResult Skill(UserData userDataa)
        {
           
                UserData.CoverLetter = userDataa.CoverLetter;



                UserData.PersonalInfo = userDataa.PersonalInfo;


                return View(UserData);
        

          
        }


        [HttpPost]
        [Authorize]
        public IActionResult Experience(UserData userDataa)
        {
           

                UserData.Skill = userDataa.Skill;
                UserData.CoverLetter = userDataa.CoverLetter;
                UserData.PersonalInfo = userDataa.PersonalInfo;
          

            return View(UserData);
        }


        [HttpPost]
        [Authorize]
        public IActionResult Project(UserData userDataa)
        { 
      
                UserData.Experiences = userDataa.Experiences;

                UserData.Skill = userDataa.Skill;
                UserData.CoverLetter = userDataa.CoverLetter;
                UserData.PersonalInfo = userDataa.PersonalInfo;
            

            return View(UserData);
        }


        [HttpPost]
        [Authorize]
        public IActionResult Link(UserData userDataa)
        {
           
                UserData.Projects = userDataa.Projects;

                UserData.Experiences = userDataa.Experiences;
            

                UserData.Skill = userDataa.Skill;
                UserData.CoverLetter = userDataa.CoverLetter;
                UserData.PersonalInfo = userDataa.PersonalInfo;
            
            return View(UserData);
        }
        [HttpPost, Authorize]
        public IActionResult createCv(UserData userDataa)
        {
            if (ModelState.IsValid == true)
            {
                UserData.Links = userDataa.Links;

                UserData.Projects = userDataa.Projects;

                UserData.Experiences = userDataa.Experiences;

                UserData.Skill = userDataa.Skill;
                UserData.CoverLetter = userDataa.CoverLetter;
                UserData.PersonalInfo = userDataa.PersonalInfo;

                ViewData["img"] = userDataa.PersonalInfo.Photo;

                context.UserData.Add(UserData);
                context.SaveChanges();

            
            }
            return View("SliderLayout", userDataa);
        }
    }
}
