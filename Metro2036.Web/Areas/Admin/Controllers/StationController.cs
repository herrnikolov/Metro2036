using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Metro2036.Services.Interfaces;
using Metro2036.Services.Models.Station;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Metro2036.Web.Areas.Admin.Controllers
{
    public class StationController : BaseController
    {
        private IStationService _stationService;

        public StationController(IStationService stationService)
        {
            _stationService = stationService;
        }

        // GET: Station
        public ActionResult Index()
        {
            var model = new StationIndexViewModel();
            model.Stations = _stationService.GetAll();
            return View(model);
        }

        // GET: Station/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Station/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Station/Create
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

        // GET: Station/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Station/Edit/5
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

        // GET: Station/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Station/Delete/5
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