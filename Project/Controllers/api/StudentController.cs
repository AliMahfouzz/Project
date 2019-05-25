using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project.Controllers.api
{
    public class StudentController : ApiController
    {
        private ApplicationDbContext db;

        public StudentController() {
            db = new ApplicationDbContext();
        }
        public IEnumerable<Student> GetStudents()
        {
            return db.Students.ToList();

        }
        //Get /api/student
        public Student GetStudent(String email) {

            var student = db.Students.SingleOrDefault(c=>c.StudentEmail == email);

            if (student == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return student;

        }
        //post/api/student
        [HttpPost]
        public Student PostStudent(Student student)
        {


            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            db.Students.Add(student);
            db.SaveChanges();

            return student;

        }
        [HttpPost]
        public void UpdateStudent(String Id, Student student) {

            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var studentInDb = db.Students.SingleOrDefault(c => c.StudentId == Id);

            if (studentInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            studentInDb.FirstName = student.FirstName;
            studentInDb.FatherName = student.FatherName;
            studentInDb.LastName = student.LastName;
            studentInDb.StudentEmail = student.StudentEmail;
            studentInDb.Address = student.Address;
            studentInDb.HomeNumber = student.HomeNumber;
            studentInDb.Department = student.Department;
            studentInDb.Gender = student.Gender;
            studentInDb.ParentId = student.ParentId;
            studentInDb.DateOfBirth = student.DateOfBirth;

            db.SaveChanges();

        }
        //DELETE /API/STUDENTS
        [HttpDelete]
        public void DeleteStudent(String Id) {

            var studentInDb = db.Students.SingleOrDefault(c => c.StudentId == Id);

            if (studentInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            db.Students.Remove(studentInDb);
            db.SaveChanges();

        }





    }
}
