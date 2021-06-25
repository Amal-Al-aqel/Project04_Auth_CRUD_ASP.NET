using FluentValidation;
using Microsoft.AspNetCore.Authorization;
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
    public class SubjectController : Controller
    {
        private readonly ApplicationDbContext _db;
        
        public SubjectController(ApplicationDbContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {
            var Subjects = _db.Subjects.ToList();
            ViewData["Subjects"] = Subjects;
            return View("Index");
        }

        public List<Subject> IndexTest()
        {
            var Subjects = _db.Subjects.ToList();            
            return Subjects;
        }

        //GET - /subject/create
        public IActionResult Create()
        {            
            return View("Create");
        }

        //POST - /subject/create
        [HttpPost]
        public IActionResult Create([Bind("SubjectName")] Subject subject)
        {
            SubjectValidator validator = new SubjectValidator(_db);
            FluentValidation.Results.ValidationResult result = validator.Validate(subject);

            if (result.IsValid) { 
            if (ModelState.IsValid)
            {                             
                _db.Subjects.Add(subject);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            } else
            {
                ViewData["Error"] = result.Errors;
                return View();
            }
            return RedirectToAction("Index");
        }

        //GEt - /subject/edit/id
        public IActionResult Edit(int? id)
        {
            var Subject = _db.Subjects.ToList().Find(s => s.Id == id);
            if (id == null || Subject == null)
            {
                return View("_NotFound");
            }
            ViewData["Subject"] = Subject;
            return View();
        }

        //POST - /subject/edit/id
        [HttpPost]
        public IActionResult Edit([Bind("Id", "SubjectName")] Subject subject)
        {
            _db.Subjects.Update(subject);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Subject subject = new Subject();
            subject = _db.Subjects.Find(id);
            _db.Subjects.Remove(subject);
            _db.SaveChanges();
            Response.Redirect("/Subject");
            return View("Index");
        }

        public List<Subject> DeleteTest(int id)
        {
            Subject subject = new Subject();
            subject = _db.Subjects.Find(id);
            _db.Subjects.Remove(subject);
            _db.SaveChanges();
            return _db.Subjects.ToList();
        }
    }
}
