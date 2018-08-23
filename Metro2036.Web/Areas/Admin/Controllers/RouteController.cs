namespace Metro2036.Web.Areas.Admin.Controllers
{
    using AutoMapper;
    using Metro2036.Models;
    using Metro2036.Services.Interfaces;
    using Metro2036.Services.Models.Route;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class RouteController : BaseController
    {
        private IRouteService _routeService;

        public RouteController(IRouteService routeService)
        {
            _routeService = routeService;
        }

        // GET: Index
        //public ActionResult Index()
        //{
        //    var model = new {Stations = _routeService.GetAll()};
        //    return View(model);
        //}
        public async Task<IActionResult> Index()
        {
            var station = await this._routeService
                .GetAll<RouteListingServiceModel>();

            return this.View(station);
        }

        // GET: /Details/id
        public ActionResult Details(int id)
        {
            var route = _routeService.Get(id);

            var model = Mapper.Map<RouteListingViewModel>(route);

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
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: /Edit/id
        public ActionResult Edit(int id)
        {
            var route = _routeService.Get(id);

            var model = Mapper.Map<RouteListingViewModel>(route);

            return View(model);
        }

        // POST: /Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RouteListingViewModel route)
        {
            var model = Mapper.Map<Route>(route);

            if (ModelState.IsValid)
            {
                _routeService.Update(model);
                return RedirectToAction("Details", "Route", new { id = model.Id });
            }
            return View();
        }

        // GET: /Delete/id
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var route = _routeService.Get(id);

            var model = Mapper.Map<RouteListingViewModel>(route);

            return View(model);
        }

        // POST: /Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(RouteListingViewModel route)
        {
            var model = Mapper.Map<Route>(route);

            _routeService.Delete(model);
            return RedirectToAction("Index", "Station");

        }
    }
}