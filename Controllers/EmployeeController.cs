using FirstMVCApps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVCApps.Controllers
{
    public class EmployeeController : Controller
    {

        Logic _logic = new Logic();

        // GET: Employee
        [HttpGet]
        public ActionResult Info()
        {
            return View(_logic.GetAllEmployee());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            var details = _logic.GetAllEmployee().Find(de => de.RegId == id);
            return View(details);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(InsertEmployeeModel insertEmployee)
        {
            try
            {
                // TODO: Add insert logic here
                _logic.InsertEmp(insertEmployee);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
