using MVCApps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApps.Controllers
{
    public class StudentsController : Controller
    {
        Logic _logic = new Logic();
        // GET:                            Lists Of Students
        [HttpGet]
        public ActionResult Lists()
        {
            return View(_logic.GetAllStudentsDetails());
        }

        // GET:                     GetDetails     Students/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            var details = _logic.GetAllStudentsDetails().Find(de => de.RollNo == id);
            return View(details);
        }

        // GET: Students/Create
        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        public ActionResult Insert(InsertModel insertStdValues)
        {
            try
            {
                // TODO: Add insert logic here
                _logic.insertDetails(insertStdValues);

                return RedirectToAction("Lists");
            }
            catch
            {
                return View();
            }
        }
        // GET: Students/Edit/5
        public ActionResult Edit(int id)
        {
            var students = _logic.GetAllStudentsDetails().Find(s => s.RollNo == id);
            return View(students);
        }

        // POST: Students/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EditModel EditStdValues)
        {
            try
            {
                // TODO: Add update logic here
                _logic.EditDetails(EditStdValues);

                return RedirectToAction("Lists");
            }
            catch
            {
                _logic.EditDetails(EditStdValues);
                return View(EditStdValues);
            }
            return View(EditStdValues);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int id)
        {
            /*
            var delStd = _logic.GetAllStudentsDetails().Find(s => s.RollNo == id); // Reuse method from Edit logic
            return View(delStd);*/
            var student = _logic.GetAllStudentsDetails().Find(de => de.RollNo == id); ; // Reuse method from Edit logic
            if (student == null)
            {
                return HttpNotFound();
            }

            DeleteModel model = new DeleteModel { RollNo = student.RollNo };
            return View(model);
        }
        
        // POST: Students/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, DeleteModel DeleteStdValues)
        {
            try
            {
                // TODO: Add delete logic here
                _logic.DeleteDetails(DeleteStdValues);
                return RedirectToAction("Lists");
            }
            catch
            {
                return View(DeleteStdValues);
            }
        }
        

    }
}
