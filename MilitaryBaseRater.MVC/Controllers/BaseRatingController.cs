using Microsoft.AspNet.Identity;
using MilitaryBaseRater.Models.RatingModels;
using MilitaryBaseRater.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilitaryBaseRater.MVC.Controllers
{
    public class BaseRatingController : Controller
    {
        // GET: BaseRating
        public ActionResult Index()
        {
            return View();
        }
        //GET BaseRating Create
        public ActionResult Create()
        {
            var baseService = new BaseService();
            var baseList = baseService.GetBases();

            ViewBag.BaseID = new SelectList(baseList, "BaseID", "BaseName");

            return View();
        }
        //POST BaseRating Create
        [HttpPost]
        public ActionResult Create(RatingCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var baseService = new BaseService();
            var baseList = baseService.GetBases();

            ViewBag.BaseID = new SelectList(baseList, "BaseID", "BaseName");

            return View(model);
        }
        //GET BaseRating Details
        public ActionResult Details(int id)
        {
            var service = CreateRatingService();
            var model = service.GetRatingsByBaseID(id);
            return View(model);
        }
        //GET BaseRating Edit
        public ActionResult Edit(int id)
        {
            var service = CreateRatingService();
            var detail = service.GetRatingsByRatingID(id);
            var model = new RatingEdit
            {
                RatingID = detail.RatingID,
                OverallRating = detail.OverallRating,
                HousingRating = detail.HousingRating,
                FoodRating = detail.FoodRating,
                ActivitiesRating = detail.ActivitiesRating,
                TrainingSitesRating = detail.TrainingSitesRating,
                Comments = detail.Comments
            };
            return View(model);
        }
        //POST BaseRating Edit
        [HttpPost]
        public ActionResult Edit(int id, RatingEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.RatingID != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return View(model);
            }

            var service = CreateRatingService();

            if (service.EditBaseRating(model))
            {
                TempData["SaveResult"] = "Your rating was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your rating could not be updated");
            return View(model);
        }
        //GET BaseRating Delete
        public ActionResult Delete(int id)
        {
            var service = CreateRatingService();
            var model = service.GetRatingsByRatingID(id);
            return View(model);
        }
        //POST BaseRating Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteRating(int id)
        {
            var service = CreateRatingService();
            service.DeleteRating(id);

            TempData["SaveResult"] = "Your rating was deleted";
            return RedirectToAction("Index");
        }

        private BaseRatingService CreateRatingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BaseRatingService(userId);
            return service;
        }
    }
}