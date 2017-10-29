using HR_DAL.DbLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Migrations;

namespace HR_WebUI.Controllers
{
    public class JobTitleController : Controller
    {
        // GET: JobTitle

        HrContext context;

        public JobTitleController()
        {
            context = new HrContext();
        }
        public ActionResult Index()
        {
            var model = context.JobTitles;
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var job = context.JobTitles.Find(id);
            if (job != null)
            {
                context.JobTitles.Remove(job);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            var model = (id == 0) ? new JobTitle() : context.JobTitles.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(JobTitle obj)
        {

            if (ModelState.IsValid)
            {
                context.JobTitles.AddOrUpdate(obj);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            Dispose_();
        }
        public void Dispose_()
        {
            context.Dispose();
        }

    }
}