using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using PagedList.Core;
using System.Net.Http;
using System.Web;
using System.Text;
using Newtonsoft.Json;
using System.Dynamic;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.Extensions.Primitives;
using Microsoft.Extensions.Configuration;
using SharedModels;
using Microsoft.Extensions.Logging;
using Serilog;

namespace AAL_TUTOR5.Controllers
{
    [Route("Home")]
    //[Route("")]
    //[Authorize(Roles = "tutor")]
    public class HomeController : Controller
    {
        dbContext db;
        UserManager<IdentityUser> userManager;
        RoleManager<IdentityRole> roleManager;
        IConfiguration configuration;

        public HomeController(IConfiguration configuration, 
            UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager,
            dbContext db)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
            this.db = db;
        }

        [HttpGet("Index")]
        [HttpGet("")]
        public IActionResult Index(int page = 1)
        {
            ViewBag.title = "Logins";
            var logins = db.Logins.ToList();
            ViewBag.logins = logins;
            return View();
        }

        [HttpGet("ClearAll")]
        public IActionResult ClearAll()
        {
            db.Logins.RemoveRange(db.Logins.ToList());
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}
