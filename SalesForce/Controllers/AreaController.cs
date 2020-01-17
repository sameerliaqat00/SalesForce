using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesForce.Models.Setup;

namespace SalesForce.Controllers
{
    public class AreaController : Controller
    {
        private Area area;

        private AreaHandler areaHandler;

        private CityHandler city;

        private ZoneHandler zone;

        public AreaController()
        {
            area = new Area();
            areaHandler = new AreaHandler();
            city = new CityHandler();
            zone = new ZoneHandler();
        }
        // GET: Area
        public ActionResult Index()
        {
            if (areaHandler.AllList() != null)
            {
                var arealist = areaHandler.AllList().ToList();
                ViewBag.Zone = zone.AllList();
                ViewBag.City = city.AllList();
                return View(arealist);
            }
            else
            {
                return RedirectToAction("Create", "Area");
            }
        }

        // GET: Area/Create
        public ActionResult Create()
        {
            area.AreaId = areaHandler.GetMaxId();
            ViewBag.Zone = zone.AllList();
            ViewBag.City = city.AllList();
            return View(area);
        }

        // POST: Area/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                area.AreaId = Convert.ToInt32(collection["AreaId"]);
                area.AreaName = collection["AreaName"].ToString();
                area.AreaCode = collection["AreaCode"].ToString();
                area.Zone = collection["Zone"].ToString();
                area.City = collection["City"].ToString();
                areaHandler.Insert(area);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Area/Edit/5
        public ActionResult Edit(int AreaId)
        {
            var area = areaHandler.GetById(AreaId);
            ViewBag.Zone = zone.AllList();
            ViewBag.City = city.AllList();
            return View(area);
        }

        // POST: Area/Edit/5
        [HttpPost]
        public ActionResult Edit(int AreaId, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                area.AreaId = Convert.ToInt32(collection["AreaId"]);
                area.AreaName = collection["AreaName"].ToString();
                area.AreaCode = collection["AreaCode"].ToString();
                area.Zone = collection["Zone"].ToString();
                area.City = collection["City"].ToString();
                areaHandler.Update(area);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Area/Delete/5
        public ActionResult Delete(int AreaId)
        {
            try
            {
                // TODO: Add delete logic here
                areaHandler.Delete(AreaId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
