using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc4Application.Models;
using Webdiyer.WebControls.Mvc;
namespace Mvc4Application.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private Mvc4ApplicationEntities db = new Mvc4ApplicationEntities();

        //
        // GET: /Employee/

        public ActionResult Index()
        {
            return View(db.Employees.OrderBy(e=>e.Id).ToPagedList(1, 10));
        }

        //
        // GET: /Employee/Details/5

        public ActionResult Details(int id = 0)
        {
            Employee employee = db.Employees.Single(e => e.Id == id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //
        // GET: /Employee/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Employee/Create

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            employee.CreatedOn = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Employees.AddObject(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        //
        // GET: /Employee/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Employee employee = db.Employees.SingleOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //
        // POST: /Employee/Edit/5

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Attach(employee);
                db.ObjectStateManager.ChangeObjectState(employee, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        //
        // GET: /Employee/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Employee employee = db.Employees.Single(e => e.Id == id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //
        // POST: /Employee/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Single(e => e.Id == id);
            db.Employees.DeleteObject(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult PagedList(int? page )
        {
            page = page ?? 1;
            var data = db.Employees.ToPagedList(page.Value, 10);
            if (Request.IsAjaxRequest())
            {
                return PartialView(data);
            }

            return View(data);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}