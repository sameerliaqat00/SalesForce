using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesForce.Models.Company;

namespace SalesForce.Controllers
{
    public class CompanyController : Controller
    {
        private Company company;

        private CompanyHandler companyHandler;

        public CompanyController()
        {
            company = new Company();
            companyHandler = new CompanyHandler();
        }
        // GET: Company
        public ActionResult Index()
        {
            if (companyHandler.AllList() != null)
            {
                var companylist = companyHandler.AllList().ToList();
                return View(companylist);
            }
            else
            {
                return RedirectToAction("Create", "Company");
            }
        }

        // GET: Company/Create
        public ActionResult Create()
        {
            company.CompanyId = companyHandler.GetMaxId();
            return View(company);
        }

        // POST: Company/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                company.CompanyId = Convert.ToInt32(collection["CompanyId"]);
                company.CompanyName = collection["CompanyName"].ToString();
                company.ShortName = collection["ShortName"].ToString();
                company.Address = collection["Address"].ToString();
                company.Phone = collection["Phone"].ToString();
                company.Fax = collection["Fax"].ToString();
                company.Website = collection["Website"].ToString();
                company.Domain = collection["Domain"].ToString();
                company.NTN = collection["NTN"].ToString();
                company.GST = collection["GST"].ToString();
               
                companyHandler.Insert(company);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Company/Edit/5
        public ActionResult Edit(int CompanyId)
        {
            var company = companyHandler.GetById(CompanyId);
            return View(company);
        }

        // POST: Company/Edit/5
        [HttpPost]
        public ActionResult Edit(int CompanyId, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                company.CompanyId = Convert.ToInt32(collection["CompanyId"]);
                company.CompanyName = collection["CompanyName"].ToString();
                company.ShortName = collection["ShortName"].ToString();
                company.Address = collection["Address"].ToString();
                company.Phone = collection["Phone"].ToString();
                company.Fax = collection["Fax"].ToString();
                company.Website = collection["Website"].ToString();
                company.Domain = collection["Domain"].ToString();
                company.NTN = collection["NTN"].ToString();
                company.GST = collection["GST"].ToString();
                companyHandler.Update(company);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Company/Delete/5
        public ActionResult Delete(int CompanyId)
        {
            try
            {
                // TODO: Add delete logic here
                companyHandler.Delete(CompanyId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
