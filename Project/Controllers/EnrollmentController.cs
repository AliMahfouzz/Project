using Project.Models;
using Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class EnrollmentController : Controller
    {
        private ApplicationDbContext db;
        public EnrollmentController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Enrollment
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult ViewEnrollments()
        {
            return View(db.Enrollments.ToList());
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Add()
        {
            EnrollmentViewModel mymodel = new EnrollmentViewModel();
            mymodel.parents = db.Parents.ToList();
            mymodel.students = db.Students.ToList();
            mymodel.Courses= db.Courses.ToList();
            mymodel.teachers = db.Teachers.ToList();
            return View(mymodel);


        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Add(Enrollment enrollment)
        {
            db.Enrollments.Add(enrollment);
            db.SaveChanges();
            return RedirectToAction("ViewEnrollments","Enrollment");


        }
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult AssignTeacher()
        {
            AssigneeViewModel mymodel = new AssigneeViewModel();
            mymodel.Courses = db.Courses.ToList();
            mymodel.teachers= db.Teachers.ToList();
            return View(mymodel);


        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult AssignTeacher(Assignee enrollment)
        {
            /*
            Assignee e = new Assignee() {
                CourseName = enrollment.CourseName,
                TeacherEmail = enrollment.TeacherEmail


            };*/
            db.Assignees.Add(enrollment);
            db.SaveChanges();

           
            return RedirectToAction("Index","Home");


        }
        [Authorize(Roles = "Administrator")]
        public ActionResult ADDCLASS(Class s)
        {
            db.Classes.Add(s);
            db.SaveChanges();
            return View();


        }
        [Authorize(Roles = "Administrator")]
        public ActionResult ViewClass()
        {
            
            return View(db.Classes.ToList());


        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int ClassId)
        {

            return View(db.Classes.Where(x => x.ClassId == ClassId).FirstOrDefault());



        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Delete(int ClassId,FormCollection form)
        {
            Class c = db.Classes.Where(x => x.ClassId == ClassId).FirstOrDefault();
            db.Classes.Remove(c);
            db.SaveChanges();
           return RedirectToAction("ViewClass","Enrollment");

        }


       



        [Authorize(Roles = "Administrator")]
        public ActionResult AddDepartment(Department s)
        {
            db.Departments.Add(s);
            db.SaveChanges();
            return View();


        }
        [Authorize(Roles = "Administrator")]
        public ActionResult ViewDepartments()
        {
            
            return View(db.Departments.ToList());


        }


        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteDepartment(int DepartmentId)
        {

            return View(db.Departments.Where(x => x.DepartmentId == DepartmentId).FirstOrDefault());



        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult DeleteDepartment(int DepartmentId, FormCollection form)
        {
            Department c = db.Departments.Where(x => x.DepartmentId == DepartmentId).FirstOrDefault();
            db.Departments.Remove(c);
            db.SaveChanges();
            return RedirectToAction("ViewDepartments", "Enrollment");

        }





    }
}