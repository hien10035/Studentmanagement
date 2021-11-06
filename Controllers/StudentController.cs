using StudentsManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentsManagement.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        { 
            StudentList stuList = new StudentList();
            List<Models.Students> obj = stuList.getStudent(string.Empty).OrderBy(x=>x.Fullname).ToList();
            return View(obj);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.Students stu)
        {
            if (ModelState.IsValid)
            {
                StudentList stulist = new StudentList();
                stulist.AddStudents(stu);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(string id = "") 
        { 
            StudentList stulist = new StudentList();
            List<Models.Students> obj = stulist.getStudent(id);
            return View(obj.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(Models.Students stu)
        {
            StudentList stulist = new StudentList();
            stulist.UpdateStudents(stu);
            return RedirectToAction("Index");
        }
        public ActionResult Details(string id = " " )
        {
            StudentList stulist = new StudentList();
            List<Models.Students> obj = stulist.getStudent(id);
            return View(obj.FirstOrDefault());
        }
        public ActionResult Delete(string id = " ")
        {
            StudentList stulist = new StudentList();
            List<Models.Students> obj = stulist.getStudent(id);
            return View(obj.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(Models.Students stu)
        {
            StudentList stulist = new StudentList();
           stulist.DeleteStudent(stu);
            return RedirectToAction("Index");
        }


    }
}