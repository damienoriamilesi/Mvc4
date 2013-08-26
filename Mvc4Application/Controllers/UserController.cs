namespace Mvc4Application.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using DataAccess;
    using DataAccess.Repository;

    public class UserController : Controller
    {
        private IUser _user;

        public UserController(IUser user)
        {
            this._user = user;
        }

        public ActionResult Index()
        {
            return View(this._user.GetAll());
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(User user)
        {
            if (TryValidateModel(user))
            {
                this._user.Add(user);
                return RedirectToAction("Index");
            }

            return View(user);
        }

        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var user = this._user.Get(x => x.Id == id.Value);
                return View(user);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Update(User user)
        {
            if (TryValidateModel(user))
            {
                this._user.Update(user);
                return RedirectToAction("Index");
            }

            return View("Edit", user);
        }

        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                this._user.Delete(new User { Id = id.Value });
                return RedirectToAction("Index");
            }

            return HttpNotFound();
        }
    }
}