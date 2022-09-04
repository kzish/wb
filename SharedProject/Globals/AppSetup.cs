using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Nest;
using SharedModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Globals
{
    public class AppSetup
    {
        /// <summary>
        /// bootstrap the application
        /// </summary>
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public IHostingEnvironment env;
        public IConfiguration configuration;

        dbContext db = new dbContext();
       
        public AppSetup(IConfiguration configuration,IWebHostEnvironment env, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.env = (IHostingEnvironment)env;
            this.configuration = configuration;

            this.InitAppSettings();
            this.CreateRoles();
            this.CreateAdminUser();
            this.CreateFolders();
        }
       
        private void InitAppSettings()
        {
            AppSettings.connection_string = configuration.GetConnectionString("db");
            //dev settings here
            AppSettings.resources_folder = @"C:\AAL_RESOURCES";
            AppSettings.moodle_ws_token = "2cb31f38b05a075434014ce3cf7e5949";
            AppSettings.api_endpoint = "https://localhost:44343";
            AppSettings.moodle_api_endpoint = $"http://moodle.test/webservice/rest/server.php?wstoken={AppSettings.moodle_ws_token}&moodlewsrestformat=json";
            AppSettings.es_endpoint = "http://localhost:9200/";

            
            if (!env.IsDevelopment())
            {
                //production settings here
                AppSettings.resources_folder = @"/var/www/html/AAL/AAL_RESOURCES";
                AppSettings.moodle_ws_token = "5c7ba33a34dbc60eef27401a8d057259";
                AppSettings.api_endpoint = "http://13.244.163.207:83";
                AppSettings.moodle_api_endpoint = $"http://13.244.163.207:84/webservice/rest/server.php?wstoken={AppSettings.moodle_ws_token}&moodlewsrestformat=json";

            }
            //permanent settings for all environments
            AppSettings.db = new dbContext();
            AppSettings.logs = Path.Combine(AppSettings.resources_folder, "logs.txt");
            AppSettings.profile_pictures_folder = Path.Combine(AppSettings.resources_folder, "profile_pictures");
            //elastic search client
            var node = new Uri(AppSettings.es_endpoint);
            var settings = new ConnectionSettings(node);
            AppSettings.EsClient = new ElasticClient(settings);
            //es Mapping
            if (!AppSettings.EsClient.Indices.Exists("tutors").Exists)
            {
                var response = AppSettings.EsClient.Indices.Create("tutors",
                   index => index.Map<Globals.apiTutor>(
                       x => x.AutoMap()
                   ));
            //https://csharp.hotexamples.com/examples/Nest/CreateIndexDescriptor/-/php-createindexdescriptor-class-examples.html
            //https://titanwolf.org/Network/Articles/Article?AID=bba6a347-bf3a-4517-a1c2-ddeca87ec68f
            }

        }

        private void CreateRoles()
        {
            //
            if (!roleManager.RoleExistsAsync("admin").Result)
                roleManager.CreateAsync(new IdentityRole("admin"));
            //
            if (!roleManager.RoleExistsAsync("tutor").Result)
                roleManager.CreateAsync(new IdentityRole("tutor"));
            //
            if (!roleManager.RoleExistsAsync("student").Result)
                roleManager.CreateAsync(new IdentityRole("student"));
        }

        private void CreateAdminUser()
        {
            string admin_email = "admin@rubiem.com";
            string admin_password = "Rubiem#99";
            //
            var exist = db.Aspnetusers.Where(i => i.Email == "admin@rubiem.com").Any();
            if (!exist)
            {
                var admin_user = new IdentityUser();
                admin_user.Email = admin_email;
                admin_user.UserName = admin_email;
                userManager.CreateAsync(admin_user, admin_password).Wait();
                userManager.AddToRoleAsync(admin_user, "admin");//add user to admin role
            }
        }

        private void CreateFolders()
        {
            Directory.CreateDirectory(AppSettings.resources_folder);
            Directory.CreateDirectory(AppSettings.profile_pictures_folder);
            if(!File.Exists(AppSettings.logs))
            {
                File.Create(AppSettings.logs);
            }
        }

       
    }


}
