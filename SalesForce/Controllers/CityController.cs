using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesForce.Models.Setup;

namespace SalesForce.Controllers
{
    public class CityController : Controller
    {
        private City city;

        private CityHandler cityHandler;
        private ZoneHandler zoneHandler;
        public CityController()
        {
            city = new City();
            cityHandler = new CityHandler();
            zoneHandler = new ZoneHandler();
        }
        // GET: City
        public ActionResult Index()
        {
            if (cityHandler.AllList() != null)
            {
                var citylist = cityHandler.AllList().ToList();
                ViewBag.Zone = zoneHandler.AllList();
                return View(citylist);
            }
            else
            {
                return RedirectToAction("Create", "City");
            }
        }

        // GET: City/Create
        public ActionResult Create()
        {
            city.CityId = cityHandler.GetMaxId();
            ViewBag.Zone = zoneHandler.AllList();
            return View(city);
        }

        // POST: City/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                city.CityId = Convert.ToInt32(collection["CityId"]);
                city.CityName = collection["CityName"].ToString();
                city.CityCode = collection["CityCode"].ToString();
                city.Zone = collection["Zone"].ToString();
                cityHandler.Insert(city);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: City/Edit/5
        public ActionResult Edit(int CityId)
        {
            var city = cityHandler.GetById(CityId);
            ViewBag.Zone = zoneHandler.AllList();
            return View(city);
        }

        // POST: City/Edit/5
        [HttpPost]
        public ActionResult Edit(int CityId, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                city.CityId = Convert.ToInt32(collection["CityId"]);
                city.CityName = collection["CityName"].ToString();
                city.CityCode = collection["CityCode"].ToString();
                city.Zone = collection["Zone"].ToString();
                cityHandler.Update(city);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: City/Delete/5
        public ActionResult Delete(int CityId)
        {
            try
            {
                // TODO: Add delete logic here
                cityHandler.Delete(CityId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

       
    }
}
