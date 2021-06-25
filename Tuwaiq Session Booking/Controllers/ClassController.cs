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
    public class ClassController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ClassController(ApplicationDbContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {
            var Classes = _db.Classes.ToList();
            ViewData["Classes"] = Classes;
            return View();
        }


        //GET - /Class/create
        [Authorize(Roles = "Instructor")]
        public IActionResult Create()
        {            
            return View();
        }

        //POST - /Class/create
        [Authorize(Roles = "Instructor")]
        [HttpPost]
        public IActionResult Create([Bind("ClassName", "Floor")] Class Class)
        {
            ClassValidator validator = new ClassValidator(_db);
            FluentValidation.Results.ValidationResult result = validator.Validate(Class);

            if (result.IsValid) { 
            if (ModelState.IsValid)
            {                             
                _db.Classes.Add(Class);
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

        //GEt - /Class/edit/id
        [Authorize(Roles = "Instructor")]
        public IActionResult Edit(int? id)
        {
            var Class = _db.Classes.ToList().Find(s => s.Id == id);
            if (id == null || Class == null)
            {
                return View("_NotFound");
            }
            ViewData["Class"] = Class;
            return View();
        }

        //POST - /Class/edit/id
        [HttpPost]
        [Authorize(Roles = "Instructor")]
        public IActionResult Edit([Bind("Id", "ClassName", "Floor")] Class Class)
        {
            _db.Classes.Update(Class);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Instructor")]
        public IActionResult Delete(int id)
        {
            Class Class = new Class();
            Class = _db.Classes.Find(id);
            _db.Classes.Remove(Class);
            _db.SaveChanges();
            Response.Redirect("/Class");
            return View("Index");
        }
    }
}
