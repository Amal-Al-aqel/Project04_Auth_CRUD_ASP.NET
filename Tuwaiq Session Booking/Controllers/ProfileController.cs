using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Web;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tuwaiq_Session_Booking.Data;
using Tuwaiq_Session_Booking.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace Tuwaiq_Session_Booking.Controllers
{
    [Authorize]
    public class profileController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ApplicationDbContext _db;
        private readonly ILogger<profileController> _logger;


        public profileController(ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<profileController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;        
            _db = context;
            _logger = logger;

        }

        public IActionResult Claims()
        {
            return View();
        }

        public IActionResult Index(string id)
        {
            //string userId = _userManager.GetUserId(User);
            var Profile = _db.Profiles.ToList().Find(p => p.ApplicationUserId == id);
            var Profiles = _db.Profiles.ToList();
            var FindUser = _db.Users.ToList().Find(u => u.Id == id);
            ViewData["Profile"] = Profile;
            ViewData["Profiles"] = Profiles;
            ViewData["User"] = FindUser;
            return View();
        }

        public IActionResult Instructors()
        {            
            var AllUsers = _db.Users.ToList();            
            //var Roles = _db.Roles.ToList();
            var Instructor = _db.Roles.ToList().Find(R => R.Name == "Instructor");
            var Student = _db.Roles.ToList().Find(R => R.Name == "Student");
            var Instructors = _db.UserRoles.ToList().FindAll(UR => UR.RoleId == Instructor.Id);
            var Students = _db.UserRoles.ToList().FindAll(UR => UR.RoleId == Student.Id);
            var Profiles = _db.Profiles.ToList();
            ViewData["AllUsers"] = AllUsers;
            //ViewData["UsersRoles"] = UserRoles;
            ViewData["Instructors"] = Instructors;
            ViewData["Students"] = Students;
            ViewData["Profiles"] = Profiles;


            return View();
        }

        public IActionResult Students()
        {
            var AllUsers = _db.Users.ToList();
            var Instructor = _db.Roles.ToList().Find(R => R.Name == "Instructor");
            var Student = _db.Roles.ToList().Find(R => R.Name == "Student");
            var Instructors = _db.UserRoles.ToList().FindAll(UR => UR.RoleId == Instructor.Id);
            var Students = _db.UserRoles.ToList().FindAll(UR => UR.RoleId == Student.Id);
            var Profiles = _db.Profiles.ToList();
            ViewData["AllUsers"] = AllUsers;            
            ViewData["Instructors"] = Instructors;
            ViewData["Students"] = Students;
            ViewData["Profiles"] = Profiles;


            return View();
        }

        public IActionResult Edit(int? Id)
        {
            var Profile = _db.Profiles.ToList().Find(p => p.Id == Id);
            if (Id == null || Profile == null)
            {
                return View("_NotFound");
            }
            ViewData["Profile"] = Profile;
            return View();
        }

        [HttpPost]
        public IActionResult Edit([Bind("Id", "ImageData", "ApplicationUserId", "FirstName", "LastName")] Profile profile, IFormFile ImageData)
        {
            if (ModelState.IsValid)
            {
                if (ImageData != null)
                {
                    profile.ImageSize = (int)ImageData.Length;
                    profile.FileName = ImageData.FileName;
                    if (ImageData.Length > 0)
                    //Convert Image to byte and save to database
                    {
                        byte[] p1 = null;
                        using (var fs1 = ImageData.OpenReadStream())
                        using (var ms1 = new MemoryStream())
                        {
                            fs1.CopyTo(ms1);
                            p1 = ms1.ToArray();
                        }
                        profile.ImageData = p1;

                    }
                }

                _db.Profiles.Update(profile);
                _db.SaveChanges();
                return Redirect("~/Identity/Account/Manage");
                //return RedirectToAction("Index");
            }
            return RedirectToAction("~/Identity/Account/Manage");            
        }
    }
}
