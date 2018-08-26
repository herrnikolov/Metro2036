namespace Metro2036.Web.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Metro2036.Services.Interfaces;
    using Metro2036.Services.Models.Route;
    using Metro2036.Services.Models.Train;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class TrainController : BaseController
    {
        private ITrainService _trainService;

        public TrainController(ITrainService trainService)
        {
            _trainService = trainService;
        }
        // GET: Train
        public ActionResult Index()
        {
            var model = new TrainIndexViewModel { Trains = _trainService.GetAll() };
            return View(model);
        }

        // GET: Train/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Train/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Train/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Train/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Train/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Train/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Train/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}