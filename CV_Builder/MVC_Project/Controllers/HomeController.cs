using Final.Models;
using Final.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace Final.Controllers
{
    public class HomeController : Controller
    {
        Context context = new Context();
        private readonly ILogger<HomeController> logger;
		ITemplatesRepository tempRepository;
		ICommentRepository commentRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(UserManager<ApplicationUser> userManager, ILogger<HomeController> _logger, ITemplatesRepository _tempRepo, ICommentRepository _comRepo)
        {
            logger = _logger;
            tempRepository= _tempRepo;
            commentRepository= _comRepo;
            _userManager = userManager;
        }
        [Authorize]
        public async Task<IActionResult> IndexAsync()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            string imreBase64Data = Encoding.Default.GetString(currentUser.image);
            ViewData["UserImg"] = imreBase64Data;
            return View();
        }
        [Authorize]
        public async Task<IActionResult> PostsAsync(int id)
        {
            CvTemplate temp = tempRepository.GetById(id);
            Comment comment= context.Comments.FirstOrDefault(c=> c.TemplateId == id);
            
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null)
            {

                string imreBase64Data = Encoding.Default.GetString(currentUser.image);

                ViewBag.Image = imreBase64Data;

            }
            

            return View(temp);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Posts(CvTemplate cvTemplate,int id)
        {
            CvTemplate temp = tempRepository.GetById(id);
            tempRepository.Update(id, cvTemplate);

            return View(temp);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> AllTemplatesAsync()
		{
            var currentUser = await _userManager.GetUserAsync(User);
            string imreBase64Data = Encoding.Default.GetString(currentUser.image);
            ViewData["UserImg"] = imreBase64Data;

            return View();
		}



		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}