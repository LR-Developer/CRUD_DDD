using AutoMapper;
using CRUD_DDD.Domain.Contracts.Services;
using CRUD_DDD.Domain.Entities;
using CRUD_DDD.MVC.ViewModels;
using Rotativa.MVC;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Web.Mvc;

namespace CRUD_DDD.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerServices _services;

        public HomeController(ICustomerServices services)
        {
            _services = services;
        }

        // GET: Home
        public ActionResult Index(Boolean? genReport)
        {
            var customerViewModel = Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(_services.GetAll());

            if (genReport != true)
            {
                return View(customerViewModel);
            }
            else
            {
                var pdf = new ViewAsPdf
                {
                    ViewName = "CustomersList",
                    Model = customerViewModel
                };

                return pdf;
            }
        }

        public ActionResult CustomersList()
        {
            var customerViewModel = Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(_services.GetAll());

            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            string[] genders = { "Masculino", "Feminino", "Outro" };
            ViewBag.Genders = new SelectList(genders);
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerViewModel customer)
        {
            if (ModelState.IsValid)
            {
                var customerDomain = Mapper.Map<CustomerViewModel, Customer>(customer);
                _services.Add(customerDomain);

                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var customer = _services.GetById(id);
            var customerViewModel = Mapper.Map<Customer, CustomerViewModel>(customer);
            return View(customerViewModel);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(CustomerViewModel customer)
        {
            if (ModelState.IsValid)
            {
                var customerDomain = Mapper.Map<CustomerViewModel, Customer>(customer);
                _services.Update(customerDomain);

                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = _services.GetById(id);
            var customerViewModel = Mapper.Map<Customer, CustomerViewModel>(customer);
            return View(customerViewModel);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                var customer = _services.GetById(id);
                _services.Remove(customer);

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
