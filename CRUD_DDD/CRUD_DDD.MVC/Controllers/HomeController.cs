using AutoMapper;
using CRUD_DDD.MVC.ViewModels;
using CRUD_DDD.Services.Customers;
using Rotativa.MVC;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CRUD_DDD.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerService _services;

        public HomeController(ICustomerService services)
        {
            _services = services;
        }

        // GET: Home
        public ActionResult Index(Boolean? genReport)
        {
            var customerViewModel = Mapper.Map<IEnumerable<CustomerDto>, IEnumerable<CustomerViewModel>>(_services.GetAll());

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
            var customerViewModel = Mapper.Map<IEnumerable<CustomerDto>, IEnumerable<CustomerViewModel>>(_services.GetAll());

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
                var dto = Mapper.Map<CustomerViewModel, CustomerDto>(customer);
                _services.Add(dto);

                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var dto = _services.Find(id);
            var customerViewModel = Mapper.Map<CustomerDto, CustomerViewModel>(dto);
            return View(customerViewModel);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(CustomerViewModel customer)
        {
            if (ModelState.IsValid)
            {
                var dto = Mapper.Map<CustomerViewModel, CustomerDto>(customer);
                _services.Update(customer.Id, dto);

                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            var dto = _services.Find(id);
            var customerViewModel = Mapper.Map<CustomerDto, CustomerViewModel>(dto);
            return View(customerViewModel);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                _services.RemoveBy(id);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
