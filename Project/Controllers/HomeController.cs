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
            AttendanceViewModel mymodel = new AttendanceViewModel() {
                students = new List<Student>()
            };

            /*
            if (!string.IsNullOrWhiteSpace(model.CourseName))
            {
                String coursename = db.Courses.Where(x => x.CourseName == model.CourseName).FirstOrDefault().CourseName;
                var temp = db.Enrollments.Where(x => x.CourseName == model.CourseName).ToList();
                
                foreach (var e in temp)
                {
                   
                    Student myStu = new Student();
                    myStu.StudentEmail = e.StudentEmail;
                    var x = db.Students.Where(xx=>xx.StudentEmail == e.StudentEmail).ToList();
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
                        mymodel.students.Add(myStu);
                        
                    }
                }
                mymodel.courses = db.Courses.ToList();
                return View(mymodel);
            }
            else
            {
             //  mymodel.students = db.Students.ToList();
               mymodel.courses = db.Courses.ToList();
            }*/
            mymodel.courses = db.Courses.ToList();
            return View(mymodel);

        }

        
        public ActionResult SaveAttendance(Attendance model)
        {
            /*           var temp = db.Enrollments.Where(x=>x.CourseName == my.CourseName).ToList();
                       //  var temp = db.Enrollments.Where(x => x.CourseId == my.CourseId).ToList();
                         List<Student> listStudentsInCourse = new List<Student>();
                         foreach (var s in temp)
                         {
                             listStudentsInCourse.Add(s.Student);
                         }
              */

            if (!string.IsNullOrWhiteSpace(model.CourseName))
            {
                String coursename = db.Courses.Where(x => x.CourseName == model.CourseName).FirstOrDefault().CourseName;
                var temp = db.Enrollments.Where(x => x.CourseName == model.CourseName).ToList();
                List<Attendance> objOrder = new List<Attendance>();
                AttendanceDetail ObjorderDetails = new AttendanceDetail();
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


                        Attendance a = new Attendance { StudentEmail = myStu.StudentEmail, CourseName = coursename, date = model.date, Status = "false" };
                        objOrder.Add(a);


                    }

                }
                   
                    ObjorderDetails.attendances = objOrder;
                    return View(ObjorderDetails);
            }
            else
            {
                //  mymodel.students = db.Students.ToList();

            }


            return View(); 

        }


        [HttpPost]
        public ActionResult SaveAttendance(AttendanceDetail Order)
        {

            db.AttendanceDetails.Add(Order);
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }






        public ActionResult GetElements(DateTime CourseDate, string CourseName)
        {
            Attendance model = new Attendance()
            {
                date = CourseDate,
                CourseName = CourseName
            };
            return RedirectToAction("SaveAttendance", "Home", model);
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

            return RedirectToAction("Index", "Home");
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
