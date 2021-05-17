using Entity.Entity;
using IRepository;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RA02.Controllers
{
    [Route("[controller]/[action]")]
    public class AircraftSightingController : Controller
    {
        private readonly IGenericRepository _generic;

        public AircraftSightingController(IGenericRepository generic)
        {
            _generic = generic;
        }


        public ActionResult Index()
        {
            var results = _generic.GetAll<AircraftSighting>();
            return View(results);
        }

        /// <summary>
        /// Fetches all AircraftSightings and return the jason format.
        /// </summary>
        /// <returns></returns>
        public JsonResult FetchAircraftSightings()
        {
            var results = _generic.GetAll<AircraftSighting>();

            return Json(results, System.Web.Mvc.JsonRequestBehavior.AllowGet);
        }

        public JsonResult FetchAircraftSightingsByParams(string make, string model, string registration)
        {

            if (!String.IsNullOrEmpty(make))
            {
                return Json(_generic.GetAll<AircraftSighting>(x => x.Make == make), System.Web.Mvc.JsonRequestBehavior.AllowGet);
            }
            else if (!String.IsNullOrEmpty(model))
            {
                return Json(_generic.GetAll<AircraftSighting>(x => x.Model == model), System.Web.Mvc.JsonRequestBehavior.AllowGet);
            }
            else if (!String.IsNullOrEmpty(registration))
            {
                return Json(_generic.GetAll<AircraftSighting>(x => x.Registration == registration), System.Web.Mvc.JsonRequestBehavior.AllowGet);
            }

            return Json(_generic.GetAll<AircraftSighting>(), System.Web.Mvc.JsonRequestBehavior.AllowGet);
        }

        // GET: ASighting/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public string Create(AircraftSighting aircraftSighting)
        {
            if (ModelState.IsValid)
            {
                if (!AircraftSightingExists(aircraftSighting))
                {
                    _generic.Add(aircraftSighting);
                    _generic.SaveAll();
                }
                else
                    return Edit(aircraftSighting);
                return "AircraftSighting Created";
            }
            return "Creation Failed";
        }

        public ActionResult Edit(string Id = null)
        {
            var aircraftSighting = _generic.GetAll<AircraftSighting>(x => x.Id == Convert.ToInt32(Id));
            if (aircraftSighting == null)
            {
                return null;
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ViewBag.InitialData = serializer.Serialize(aircraftSighting);
            return View();
        }

        /// <summary>
        /// Edits particular AircraftSighting details
        /// </summary>
        /// <param name="aircraftSighting"></param>
        /// <returns></returns>
        [HttpPost]
        public string Edit(AircraftSighting aircraftSighting)
        {
            if (ModelState.IsValid)
            {
                _generic.Update(aircraftSighting);
                _generic.SaveAll();
                return "AircraftSighting Edited";
            }
            return "Edit Failed";
        }

        public ActionResult Delete(string Id = null)
        {
            var aircraftSighting = _generic.GetAll<AircraftSighting>(x => x.Id == Convert.ToInt32(Id));

            if (aircraftSighting == null)
            {
                return null;
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ViewBag.InitialData = serializer.Serialize(aircraftSighting);
            return View();
        }

        public ActionResult Details(string Id = null)
        {
            var aircraftSighting = _generic.GetAll<AircraftSighting>(x => x.Id == Convert.ToInt32(Id));
            if (aircraftSighting == null)
            {
                return null;
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ViewBag.InitialData = serializer.Serialize(aircraftSighting);
            return View();
        }

        /// <summary>
        /// Delete particular AircraftSighting details
        /// </summary>
        /// <param name="aircraftSighting"></param>
        /// <returns></returns>
        [HttpPost]
        public string Delete(AircraftSighting aircraftSighting)
        {
            _generic.Delete(aircraftSighting);
            _generic.SaveAll();
            return "AircraftSighting Deleted";
        }

        /// <summary>
        /// Checks if AircraftSighting exists
        /// </summary>
        /// <param name="aircraftSighting"></param>
        /// <returns></returns>
        private bool AircraftSightingExists(AircraftSighting aircraftSighting)
        {
            var foundAircraftSighting = _generic.GetAll<AircraftSighting>(x => x.Id == Convert.ToInt32(aircraftSighting.Id));
            if (foundAircraftSighting != null && !String.IsNullOrEmpty(foundAircraftSighting.Id.ToString()))
                return true;
            return false;
        }
    }
}
