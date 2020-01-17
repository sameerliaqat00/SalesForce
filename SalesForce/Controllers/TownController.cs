using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesForce.Models.Setup;

namespace SalesForce.Controllers
{
    public class TownController : Controller
    {
        private Town town;

        private TownHandler townHandler;

        public TownController()
        {
            town = new Town();
            townHandler = new TownHandler();
        }
        // GET: Town
        public ActionResult Index()
        {
            if (townHandler.AllList() != null)
            {
                var townlist = townHandler.AllList().ToList();
                return View(townlist);
            }
            else
            {
                return RedirectToAction("Create", "Town");
            }
        }

        // GET: Town/Create
        public ActionResult Create()
        {
            town.TownId = townHandler.GetMaxId();
            return View(town);
        }

        // POST: Town/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                town.TownId = Convert.ToInt32(collection["TownId"]);
                town.TownName = collection["TownName"].ToString();
                townHandler.Insert(town);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Town/Edit/5
        public ActionResult Edit(int TownId)
        {
            var town = townHandler.GetById(TownId);
            return View(town);
        }

        // POST: Town/Edit/5
        [HttpPost]
        public ActionResult Edit(int TownId, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                town.TownId = Convert.ToInt32(collection["TownId"]);
                town.TownName = collection["TownName"].ToString();
                townHandler.Update(town);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Town/Delete/5
        public ActionResult Delete(int TownId)
        {
            try
            {
                // TODO: Add delete logic here
                townHandler.Delete(TownId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
