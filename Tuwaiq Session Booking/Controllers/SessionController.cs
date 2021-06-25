using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Tuwaiq_Session_Booking.Data;
using Tuwaiq_Session_Booking.Models;


namespace Tuwaiq_Session_Booking.Controllers
{
    [Authorize]
    public class SessionController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public SessionController(ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = context;
        }

        public IActionResult Index()
        {
            var Sessions = _db.Sessions.ToList();
            var ConfirmedSessions = _db.Sessions.ToList().FindAll(s => s.Confirmed == true);
            var RequestedSessions = _db.Sessions.ToList().FindAll(s => s.Confirmed == false);
            var Subjects = _db.Subjects.ToList();
            var Classes = _db.Classes.ToList();            
            
            ViewData["Subjects"] = Subjects;
            ViewData["Classes"] = Classes;
            ViewData["Sessions"] = Sessions;
            ViewData["ConfirmedSessions"] = ConfirmedSessions;
            ViewData["RequstedSessions"] = RequestedSessions;

            if (Subjects == null || Subjects.Count == 0)
            {
                Debug.WriteLine("subject is empty!!!");
                TempData["ErrorMessage"] = "You can't add a session before adding one subject at least!!";
                Response.Redirect("/Subject");
                return View("Index");
            }

            if (Classes == null || Classes.Count == 0)
            {
                TempData["ErrorMessage"] = "You can't add a session before adding one class at least!!";
                Response.Redirect("/Class");
                return View("Index");
            }

            return View("Index");
        }

        //GET - /session/create
        //[Authorize(Roles = "Instructor")]
        public IActionResult Create()
        {
            var Subjects = _db.Subjects.ToList();
            ViewData["Subjects"] = Subjects;

            var Classes = _db.Classes.ToList();
            ViewData["Classes"] = Classes;
            return View();
        }

        //[Authorize(Roles = "Instructor")]
        //POST - /session/create
        [HttpPost]
        public IActionResult Create([Bind("Id", "SessionTime", "Duration", "Location", "Subject")] Session session,
            IFormCollection form)
        {
            string selectedSubject = form["subjects"].ToString();
            string selectedClass = form["classes"].ToString();

            var Subject = _db.Subjects.ToList().Find(s => s.SubjectName == selectedSubject);
            var classObject = _db.Classes.ToList().Find(c => c.ClassName == selectedClass);

            session.SubjectId = Subject.Id;
            session.ClassId = classObject.Id;
            string userId = _userManager.GetUserId(User);
            if (User.IsInRole("Instructor"))
            {
                session.Confirmed = true;
            } else session.Confirmed = false;

            session.ApplicationUserId = userId;

            if (ModelState.IsValid)
            {
                _db.Sessions.Add(session);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        //GET - /subject/edit/id
        [Authorize(Roles = "Instructor")]
        public IActionResult Edit(int? id)
        {            
            var Session = _db.Sessions.ToList().Find(s => s.Id == id);
            if (id == null || Session == null)
            {
                return View("_NotFound");
            }
            
            var Subjects = _db.Subjects.ToList();
            var Classes = _db.Classes.ToList();

            ViewData["Session"] = Session;
            ViewData["Subjects"] = Subjects;
            ViewData["Classes"] = Classes;
            return View();
        }

        //POST - /subject/edit/id
        [HttpPost]
        [Authorize(Roles = "Instructor")]
        public IActionResult Edit([Bind("Id", "SessionTime", "Duration", "Location", "Subject", "SubjectId", "ClassId")] Session session)
        {
            _db.Sessions.Update(session);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        //POST - /subject/edit/id
        [Authorize(Roles = "Instructor")]
        public IActionResult Confirm(int Id)
        {
            var OldSession = _db.Sessions.ToList().Find(s => s.Id == Id);
            
            Session session = new Session();
            session.Id = Id;
            session.Confirmed = true;
            session.SessionTime = OldSession.SessionTime;
            session.Duration = OldSession.Duration;
            session.Location = OldSession.Location;
            session.Subject = OldSession.Subject;
            session.SubjectId = OldSession.SubjectId;
            session.ClassId = OldSession.ClassId;

            _db.Sessions.Remove(OldSession);
            _db.Sessions.Update(session);
            _db.SaveChanges();

            Response.Redirect("/Session");
            return View("Index");
        }

        [Authorize(Roles = "Instructor")]
        public IActionResult Delete(int id)
        {
            Session session = new Session();
            session = _db.Sessions.Find(id);
            _db.Sessions.Remove(session);
            _db.SaveChanges();
            var Sessions = _db.Sessions.ToList();            
            ViewData["Sessions"] = Sessions;
            Response.Redirect("/Session");
            return View("Index");
        }

        [Authorize(Roles = "Instructor")]
        public IActionResult RequestedSessionsIndex()
        {
            var Sessions = _db.Sessions.ToList();
            var ConfirmedSessions = _db.Sessions.ToList().FindAll(s => s.Confirmed == true);
            var RequestedSessions = _db.Sessions.ToList().FindAll(s => s.Confirmed == false);            
            var Subjects = _db.Subjects.ToList();
            var Classes = _db.Classes.ToList();            
            
            ViewData["Subjects"] = Subjects;
            ViewData["Classes"] = Classes;
            ViewData["Sessions"] = Sessions;
            ViewData["ConfirmedSessions"] = ConfirmedSessions;
            ViewData["RequstedSessions"] = RequestedSessions;

            if (Subjects == null || Subjects.Count == 0)
            {
                TempData["ErrorMessage"] = "You can't add a session before adding one subject at least!!";
                Response.Redirect("/Subject");
                return View("Index");
            }

            if (Classes == null || Classes.Count == 0)
            {
                TempData["ErrorMessage"] = "You can't add a session before adding one class at least!!";
                Response.Redirect("/Class");
                return View("Index");
            }

            return View("RequestedSessionsIndex");
        }

    }
}
