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
    public class CourseController : Controller
    {
        private ApplicationDbContext db;

        public CourseController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Course
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Administrator,Teacher")]
        public ActionResult Add()
        {
            var departments = db.Departments.ToList();
            var classes = db.Classes.ToList();
            var days = db.Days.ToList();

            AddCourse dev = new AddCourse()
            {

                Departments = departments,
                Classes = classes,
                Days = days

            };
            return View(dev);
        }
        [Authorize(Roles = "Administrator,Teacher")]
        [HttpPost]
        public ActionResult Add(Course addcourse)
        {

            db.Courses.Add(addcourse);
            db.SaveChanges();

            return RedirectToAction("ViewCourses", "Course");
        }
        public ActionResult ViewCourses()
        {

            return View(db.Courses.ToList());
        }

        [Authorize(Roles = "Administrator,Teacher")]
        public ActionResult AddMaterials()
        {
            var temp = db.Courses.ToList();
            CourseProgress c = new CourseProgress()
            {


                Courses = temp

            };
            return View(c);
        }

        [Authorize(Roles = "Administrator,Teacher")]
        [HttpPost]
        public ActionResult AddMaterials(CourseProgress c)
        {

            try
            {
                if (c.file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(c.file.FileName);
                    var path = Path.Combine(Server.MapPath("~/uploads"), fileName);
                    c.file.SaveAs(path);
                    Material m = new Material() {
                        CourseName = c.Material.CourseName,
                        Date = c.Material.Date,
                        FilePath = path



                    };
                   // m.FilePath = path;
                    db.Materials.Add(m);
                    db.SaveChanges();
                }
               
                return RedirectToAction("Index","Home");
            }
            catch
            {
                ViewBag.Message = "Upload failed";
                return View();
            }




        }



        public ActionResult ViewCourseProgress()
        {

            return View(db.Courses.ToList());
        }
        
    





    }
}