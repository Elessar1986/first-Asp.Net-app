using HR_DAL.DbLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR_WebUI.Controllers
{
    public class EmployeeController : Controller
    {
        HrContext context;

        public EmployeeController()
        {
            context = new HrContext();
        }
        public ActionResult Index()
        {
            var model = context.Employees;
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            var model = (id == 0) ? new Employee() : context.Employees.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Employee obj)
        {
            if (ModelState.IsValid)
            {
                context.Employees.AddOrUpdate(obj);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public ActionResult Delete(int id)
        {
            var emp = context.Employees.Find(id);
            if(emp != null)
            {
                context.Employees.Remove(emp);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            context.Dispose();
        }
    }
}