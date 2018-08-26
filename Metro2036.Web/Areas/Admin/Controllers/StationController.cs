namespace Metro2036.Web.Areas.Admin.Controllers
{
    using AutoMapper;
    using Metro2036.Models;
    using Metro2036.Services.Interfaces;
    using Metro2036.Services.Models.Station;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    public class StationController : BaseController
    {
        private IStationService _stationService;
        private readonly IMapper _mapper;

        public StationController(IStationService stationService, IMapper mapper)
        {
            _stationService = stationService;
            _mapper = mapper;
        }

        // GET: Index
        public ActionResult Index()
        {
            var model = new StationIndexViewModel {Stations = _stationService.GetAll()};
            return View(model);
        }

        // GET: /Details/id
        public ActionResult Details(int id)
        {
            var station = _stationService.Get(id);

            var model = _mapper.Map<StationDetailsViewModel>(station);


            //if (model.Id == null)
            //{
            //    return RedirectToAction(nameof(Index));
            //}
            return View(model);
        }

        // GET: /Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StationCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var station = this._mapper.Map<Station>(model);
            _stationService.Add(station);
            return RedirectToAction("Details");

        }

        // GET: /Edit/id
        public ActionResult Edit(int id)
        {
            var station = _stationService.Get(id);

            var model = _mapper.Map<StationEditBindModel>(station);


            //if (model.Id == null)
            //{
            //    return RedirectToAction(nameof(Index));
            //}
            return View(model);
        }

        // POST: /Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StationEditBindModel station)
        {
            var model = _mapper.Map<Station>(station);

            if (ModelState.IsValid)
            {
                _stationService.Update(model);
                return RedirectToAction("Details", "Station", new { id = model.Id });
            }
            return View();
        }

        // GET: /Delete/id
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var station = _stationService.Get(id);

            var model = _mapper.Map<StationDeleteViewModel>(station);

            return View(model);
        }

        // POST: /Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(StationDeleteViewModel station)
        {
            var model = _mapper.Map<Station>(station);

            _stationService.Delete(model);
            return RedirectToAction("Index", "Station");

        }
    }
}