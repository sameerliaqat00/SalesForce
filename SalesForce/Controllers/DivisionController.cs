using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesForce.Models.Company;
using SalesForce.Models.Setup;

namespace SalesForce.Controllers
{
    public class DivisionController : Controller
    {
        private Division division;

        private DivisionHandler divisionHandler;

        private CompanyHandler company;

        public DivisionController()
        {
            division = new Division();
            divisionHandler = new DivisionHandler();
            company = new CompanyHandler();
        }
        // GET: Division
        public ActionResult Index()
        {
            if (divisionHandler.AllList() != null)
            {
                var divisionlist = divisionHandler.AllList().ToList();
                ViewBag.Company = company.AllList();
                return View(divisionlist);
            }
            else
            {
                return RedirectToAction("Create", "Division");
            }
        }
        // GET: Division/Create
        public ActionResult Create()
        {
            division.DivisionId = divisionHandler.GetMaxId();
            ViewBag.Company = company.AllList();
            return View(division);
        }

        // POST: Division/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                division.DivisionId = Convert.ToInt32(collection["DivisionId"]);
                division.DivisionName = collection["DivisionName"].ToString();
                division.CompanyName = collection["CompanyName"].ToString();
                division.CompanyCode = collection["CompanyCode"].ToString();
                divisionHandler.Insert(division);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Division/Edit/5
        public ActionResult Edit(int DivisionId)
        {
            var division = divisionHandler.GetById(DivisionId);
            ViewBag.Company = company.AllList();
            return View(division);
        }

        // POST: Division/Edit/5
        [HttpPost]
        public ActionResult Edit(int DivisionId, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                division.DivisionId = Convert.ToInt32(collection["DivisionId"]);
                division.DivisionName = collection["DivisionName"].ToString();
                division.CompanyName = collection["CompanyName"].ToString();
                division.CompanyCode = collection["CompanyCode"].ToString();
                divisionHandler.Update(division);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Division/Delete/5
        public ActionResult Delete(int DivisionId)
        {
            try
            {
                // TODO: Add delete logic here
                divisionHandler.Delete(DivisionId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
