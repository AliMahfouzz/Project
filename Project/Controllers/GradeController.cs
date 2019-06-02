using Project.Models;
using Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class GradeController : Controller
    {


        ApplicationDbContext db = new ApplicationDbContext();


    
   
    public ActionResult GetElements(string CourseName)
    {
        Grade model = new Grade()
        {

            CourseName = CourseName
        };
        return RedirectToAction("SaveGrades", "Grade", model);
        // return View();
    }


    public ActionResult SaveGrades(Grade model)
    {
      

        if (!string.IsNullOrWhiteSpace(model.CourseName))
        {
            String coursename = db.Courses.Where(x => x.CourseName == model.CourseName).FirstOrDefault().CourseName;
            var temp = db.Enrollments.Where(x => x.CourseName == model.CourseName).ToList();
            List<Grade> objOrder = new List<Grade>();
            GradeDetail ObjorderDetails = new GradeDetail();
            foreach (var e in temp)
            {

                Student myStu = new Student();
                myStu.StudentEmail = e.StudentEmail;
                var x = db.Students.Where(xx => xx.StudentEmail == e.StudentEmail).ToList();
                foreach (var q in x)
                {
                    myStu.HomeNumber = q.HomeNumber;
                    myStu.ParentId = q.ParentId;
                    myStu.Address = q.Address;
                    myStu.DateOfBirth = q.DateOfBirth;
                    myStu.DepartmentId = q.DepartmentId;
                    myStu.FatherName = q.FatherName;
                    myStu.FirstName = q.FirstName;
                    myStu.LastName = q.LastName;
                    myStu.Gender = q.Gender;
                    myStu.StudentId = q.StudentId;

                    // mymodel.students.Clear();


                    Grade a = new Grade { StudentEmail = myStu.StudentEmail, CourseName = coursename, grade = 0 };
                    objOrder.Add(a);


                }

            }

            ObjorderDetails.Grades = objOrder;
            return View(ObjorderDetails);
        }
        else
        {
            //  mymodel.students = db.Students.ToList();

        }


        return View();

    }


    [HttpPost]
    public ActionResult SaveGrades(GradeDetail GD)
    {

        db.GradeDetails.Add(GD);
        db.SaveChanges();
        return RedirectToAction("Index", "Home");
    }

        public ActionResult AddGrade(Grade model)
        {
            AttendanceViewModel mymodel = new AttendanceViewModel()
            {
                students = new List<Student>()
            };

           
            mymodel.courses = db.Courses.ToList();
            return View(mymodel);

        }






    }
}