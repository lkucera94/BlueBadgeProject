using Microsoft.AspNet.Identity;
using MilitaryBaseRater.Models;
using MilitaryBaseRater.Models.RaterModels;
using MilitaryBaseRater.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilitaryBaseRater.MVC.Controllers
{
    public class RaterController : Controller
    {
        // GET: Rater
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RaterService(userId);
            var model = service.GetRatersByUserID(userId);

            return View(model);
        }

        //GET Create
        public ActionResult Create()
        {
            var service = CreateRaterService();
            ViewBag.UserName = service.GetUserName();
            return View();
        }

        //POST Create
        [HttpPost]
        public ActionResult Create(RaterCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateRaterService();

            if (service.CreateRater(model))
            {
                TempData["SaveResult"] = "Your rater information was created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Rater information could not be created");
            return View(model);
        }
                
        //GET Details
        public ActionResult Details(int id)
        {
            var service = CreateRaterService();
            var model = service.GetRaterByID(id);

            return View(model);
        }

        //GET Edit
        public ActionResult Edit(int id)
        {
            var service = CreateRaterService();
            var detail = service.GetRaterByID(id);
            var model = new RaterEdit
            {
                UserID = detail.UserID,
                RaterID = detail.RaterID,
                Branch = detail.Branch,
                Job = detail.Job,
                Rank = detail.Rank,
                Age = detail.Age,
            };
            return View(model);
        }
        //POST Edit
        [HttpPost]
        public ActionResult Edit( RaterEdit model)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if(model.UserID != userId)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateRaterService();

            if (service.EditRater(model))
            {
                TempData["SaveResult"] = "Your information was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your information could not be updated");
            return View(model);
            
        }
        //GET Delete
        public ActionResult Delete(int id)
        {
            var service = CreateRaterService();
            var model = service.GetRaterByID(id);

            return View(model);
        }

        //POST Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteRater(int id)
        {
            var service = CreateRaterService();

            service.DeleteRater(id); 

            TempData["SaveResult"] = "Your information was deleted";
            return RedirectToAction("Index");
        }

        private RaterService CreateRaterService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RaterService(userId);
            return service;
        }
    }
}