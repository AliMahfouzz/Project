using Project.Models;
using Project.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class AssignmentController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Assignment
        [Authorize(Roles = "Student,Parent")]
        public ActionResult AddAssignment()
        {
            var temp = db.Courses.ToList();
            var t = db.Students.ToList();
            AttendanceProgress c = new AttendanceProgress()
            {
                Students = t,

                Courses = temp

            };
            return View(c);
        }

        [Authorize(Roles = "Student,Parent")]
        [HttpPost]
        public ActionResult AddAssignment(AttendanceProgress c)
        {

            try
            {
                if (c.file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(c.file.FileName);
                    var path = Path.Combine(Server.MapPath("~/assignments"), fileName);
                    c.file.SaveAs(path);
                    DAssignment m = new DAssignment()
                    {
                        CourseName = c.assignment.CourseName,
                        Date = c.assignment.Date,
                        FilePath = path,
                        StudentEmail = c.assignment.StudentEmail



                    };
                    // m.FilePath = path;
                    db.assignments.Add(m);
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                ViewBag.Message = "Upload failed";
                return View();
            }




        }
    }
}