using Final.Models;
using Final.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Drawing;
using System.Security.Claims;
using System.Text;

namespace Final.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment Environment;

        public AccountController
            (Microsoft.AspNetCore.Hosting.IHostingEnvironment _Environment, UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager)
        {
            this.userManager = _userManager;
            this.signInManager = _signInManager;
            Environment= _Environment;
        }
        Context context = new Context();
        public IActionResult Registration()
        {

            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(RegisterationViewModel newUserVM)
        
        {
            if (ModelState.IsValid)
            {
               
                ApplicationUser userModel = new ApplicationUser();
                userModel.UserName = newUserVM.UserNAme;
                userModel.PasswordHash = newUserVM.Password;
                userModel.Email = newUserVM.Email;
                userModel.image = Encoding.Default.GetBytes(newUserVM.image.FileName);
                /*string wwwPath = this.Environment.WebRootPath;
                string contentPath = this.Environment.ContentRootPath;

                string path = Path.Combine(this.Environment.WebRootPath, "/img/clients");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                    string fileName = Path.GetFileName(newUserVM.Images.FileName);
                    using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                    {
                    newUserVM.Images.CopyTo(stream);
                    }*/
                string FileName = newUserVM.Images.FileName;

                
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + FileName;

                
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/portfolio", FileName);

                
                newUserVM.Images.CopyTo(new FileStream(imagePath, FileMode.Create));

                
                IdentityResult result =
                    await userManager.CreateAsync(userModel, newUserVM.Password);


                if (result.Succeeded)
                {
                    
                    List<Claim> addClaim = new List<Claim>();
                   
                    await signInManager.SignInWithClaimsAsync(userModel, false, addClaim);
                    
                    return RedirectToAction("login", "account");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(newUserVM);
        }

        public async Task<IActionResult> signOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel userVmReq)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser userModel =
                    await userManager.FindByNameAsync(userVmReq.UserName);
                if (userModel != null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult rr =
                        await signInManager.PasswordSignInAsync(userModel, userVmReq.Password, userVmReq.RememberMe, false);
                    if (rr.Succeeded)

                        //hayro7 el main page bta3tna
                        return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Username or Password");
                }
            }
            return View(userVmReq);
        }
        public IActionResult main()
        {
            
            return View();
        }
    }
}
