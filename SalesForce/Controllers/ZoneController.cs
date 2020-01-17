using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesForce.Models.Setup;
using Zone = System.Security.Policy.Zone;

namespace SalesForce.Controllers
{
    public class ZoneController : Controller
    {
        private Zones zones;
        private ZoneHandler zoneHandler;

        public ZoneController()
        {
            zones = new Zones();
            zoneHandler = new ZoneHandler();
        }
        // GET: Zone
        public ActionResult Index()
        {
            if (zoneHandler.AllList() != null)
            {
                var zonelist = zoneHandler.AllList().ToList();
                return View(zonelist);
            }
            else
            {
                return RedirectToAction("Create", "Zone");
            }
        }

        // GET: Zone/Create
        public ActionResult Create()
        {
            zones.ZoneId = zoneHandler.GetMaxId();
            return View(zones);
        }

        // POST: Zone/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                
                    zones.ZoneId = Convert.ToInt32(collection["ZoneId"]);
                    zones.ZoneName = collection["ZoneName"].ToString();
                    zones.ZoneCode = collection["ZoneCode"].ToString();
                    zoneHandler.Insert(zones);
                    return RedirectToAction("Index");
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Zone/Edit/5
        public ActionResult Edit(int? ZoneId)
        {
            var zone = zoneHandler.GetById(ZoneId);
            return View(zone);
        }

        // POST: Zone/Edit/5
        [HttpPost]
        public ActionResult Edit(int? ZoneId, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                zones.ZoneId = Convert.ToInt32(collection["ZoneId"]);
                zones.ZoneName = collection["ZoneName"].ToString();
                zones.ZoneCode = collection["ZoneCode"].ToString();
                zoneHandler.Update(zones);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Zone/Delete/5
        public ActionResult Delete(int ZoneId)
        {
            try
            {
                // TODO: Add delete logic here
                zoneHandler.Delete(ZoneId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
