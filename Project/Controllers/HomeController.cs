using Project.Models;
using Project.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db;
        public HomeController()
        {
            db = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddAttendance(Attendance model)
        {
            AttendanceViewModel mymodel = new AttendanceViewModel();


            if (!string.IsNullOrWhiteSpace(model.CourseName))
            {
                String coursename = db.Courses.Where(x => x.CourseName == model.CourseName).FirstOrDefault().CourseName;
                var temp = db.Enrollments.Where(x => x.CourseName == coursename).ToList();

                foreach (var e in temp)
                {
                    Student myStu = new Student()
                    {
                        StudentEmail = e.StudentEmail
                    };
                    mymodel.students.Add(myStu);
                }
                mymodel.courses = db.Courses.ToList();
            }
            else
            {
                mymodel.students = db.Students.ToList();
                mymodel.courses = db.Courses.ToList();
            }

            return View(mymodel);

        }

        [HttpPost]
        public ActionResult AddAttendance(AttendanceViewModel my)
        {
            /*  var temp = db.Enrollments.Where(x => x.CourseId == my.CourseId).ToList();
              List<Student> listStudentsInCourse = new List<Student>();
              foreach (var s in temp)
              {
                  listStudentsInCourse.Add(s.Student);
              }
              */
            return View(my);

        }
        public ActionResult GetElements(DateTime CourseDate, string CourseName)
        {
            Attendance model = new Attendance()
            {
                date = CourseDate,
                CourseName = CourseName
            };
            return RedirectToAction("AddAttendance", "Home", model);
            // return View();
        }


        public ActionResult RegisterTeacher()
        {
            return View();
        }

        public ActionResult RegisterStu()
        {
            return View();
        }
        public ActionResult RegisterParent()
        {
            return View();
        }

        public ActionResult About()
        {


            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(Contact e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add("arm037@usal.edu.lb");
                mail.From = new MailAddress(e.Email);
                mail.Subject = e.Subject;

                string userMessage = "";
                userMessage = "<br/>Name :" + e.Name;
                userMessage = userMessage + "<br/>Email Id: " + e.Email;
                userMessage = userMessage + "<br/>Phone No: " + e.PhoneNumber;
                userMessage = userMessage + "<br/>Message: " + e.Message;
                string Body = "Hi, <br/><br/> A new enquiry by user. Detail is as follows:<br/><br/> " + userMessage + "<br/><br/>Thanks";


                mail.Body = Body;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                //SMTP Server Address of gmail
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("arm037@usal.edu.lb", "m@h@li123");
                // Smtp Email ID and Password For authentication
                smtp.EnableSsl = true;
                smtp.Send(mail);
                ViewBag.Message = "Thank you for contacting us.";
            }
            catch
            {
                ViewBag.Message = "Error............";
            }

            return View();
        }
        /*
        public ActionResult Addas()
        {


            // Assignment mymodel = new Assignment();
            //mymodel.parents = db.Parents.ToList();
            var students = db.Students.ToList();
            var courses = db.Courses.ToList();

            Assignment dev = new Assignment()
            {
                Students = students,
                Courses = courses

            };


            return View(dev);
        }
        [HttpPost]
        public ActionResult Addas(Assignment model)
        {


            return View();
        }


    */
       




    }
}
