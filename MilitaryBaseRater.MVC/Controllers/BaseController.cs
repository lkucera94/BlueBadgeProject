using Microsoft.AspNet.Identity;
using MilitaryBaseRater.Models.BaseModels;
using MilitaryBaseRater.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilitaryBaseRater.MVC.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public ActionResult Index(Guid id)
        {
            var service = new BaseService();
            var model = service.GetBasesByUserID(id);
            return View(model);
        }

        //GET Base Create
        public ActionResult Create()
        {
            return View();
        }

        //POST Base Create
        [HttpPost]
        public ActionResult Create(BaseCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new BaseService();
            if (service.CreateBase(model))
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Base could not be added");
            return View(model);
        }
        //GET Base Details
        public ActionResult Details(int id)
        {
            var service = new BaseService();
            var model = service.GetBaseByID(id);

            return View(model);
        }
        //GET Base Edit
        public ActionResult Edit(int id)
        {
            var service = new BaseService();
            var detail = service.GetBaseByID(id);
            var model = new BaseEdit
            {
                BaseID = detail.BaseID,
                BaseName = detail.BaseName,
                BaseCity = detail.BaseCity,
                BaseState = detail.BaseState

            };
            return View(model);
        }
        //POST Base Edit
        [HttpPost]
        public ActionResult Edit(int id, BaseEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if(model.BaseID != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return View(model);
            }

            var service = new BaseService();

            if (service.EditBase(model))
            {
                TempData["SaveResult"] = "Your base was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your base could not be updated");
            return View(model);
        }
        //GET Base Delete
        public ActionResult Delete(int id)
        {
            var service = new BaseService();
            var model = service.GetBaseByID(id);
            return View(model);
        }
        //POST Base Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteBase(int id)
        {
            var service = new BaseService();

            service.DeleteBase(id);

            TempData["SaveResult"] = "Your base was deleted";
            return RedirectToAction("Index");
        }

      
    }
}