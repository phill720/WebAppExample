using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppExample.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            NorthwindEntities dbcontext = new NorthwindEntities();
            List<Customer> customers = dbcontext.Customers.ToList();
            return View(customers);
        }

        // GET: Customer/Details/5
        public ActionResult Details(string id)
        {
            NorthwindEntities dbcontext = new NorthwindEntities();
            Customer customer = dbcontext.Customers.Find(id);
            if (customer == null)
            {
                return View("NotFound");
            }
            return View(customer);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            NorthwindEntities dbcontext = new NorthwindEntities();
            //if (ModelState.IsValid)
            //{
            //    //dbcontext.Customers.Add();
            //    return RedirectToAction("Create");
            //}
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                NorthwindEntities dbcontext = new NorthwindEntities();
                Customer customer = new Customer();
                // TODO: Add insert logic here
                //----------------------------------------------------
                customer.Address = collection["Address"].ToString(); dbcontext.SaveChanges();
                customer.City = collection["City"].ToString(); dbcontext.SaveChanges();
                customer.CompanyName = collection["CompanyName"].ToString(); dbcontext.SaveChanges();
                customer.ContactName = collection["ContactName"].ToString(); dbcontext.SaveChanges();
                customer.ContactTitle = collection["ContactTitle"].ToString(); dbcontext.SaveChanges();
                customer.Country = collection["Country"].ToString(); dbcontext.SaveChanges();
                customer.CustomerID = collection["CustomerID"].ToString(); dbcontext.SaveChanges();
                customer.Fax = collection["Fax"].ToString(); dbcontext.SaveChanges();
                customer.Phone = collection["Phone"].ToString(); dbcontext.SaveChanges();
                customer.PostalCode = collection["PostalCode"].ToString(); dbcontext.SaveChanges();
                customer.Region = collection["Region"].ToString(); dbcontext.SaveChanges();
                dbcontext.Customers.Add(customer); dbcontext.SaveChanges();
                //-----------------------------------------------------
                return RedirectToAction("Index", collection);
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(string id)
        {
            NorthwindEntities dbcontext = new NorthwindEntities();
            Customer customer = dbcontext.Customers.Find(id);
            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                NorthwindEntities dbcontext = new NorthwindEntities();

                Customer customer = dbcontext.Customers.Find(id);

                //----------------------------------------------------
                customer.Address = collection["Address"].ToString(); dbcontext.SaveChanges();
                customer.City = collection["City"].ToString(); dbcontext.SaveChanges();
                customer.CompanyName = collection["CompanyName"].ToString(); dbcontext.SaveChanges();
                customer.ContactName = collection["ContactName"].ToString(); dbcontext.SaveChanges();
                customer.ContactTitle = collection["ContactTitle"].ToString(); dbcontext.SaveChanges();
                customer.Country = collection["Country"].ToString(); dbcontext.SaveChanges();
                customer.CustomerID = collection["CustomerID"].ToString(); dbcontext.SaveChanges();
                customer.Fax = collection["Fax"].ToString(); dbcontext.SaveChanges();
                customer.Phone = collection["Phone"].ToString(); dbcontext.SaveChanges();
                customer.PostalCode = collection["PostalCode"].ToString(); dbcontext.SaveChanges();
                customer.Region = collection["Region"].ToString(); dbcontext.SaveChanges();
                //-----------------------------------------------------

                //dbcontext.Customers
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(string id)
        {
            NorthwindEntities dbcontext = new NorthwindEntities();
            Customer customer = dbcontext.Customers.Find(id);
            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {// TODO: Add delete logic here------------------------------
            NorthwindEntities dbcontext = new NorthwindEntities();
            Customer customer = dbcontext.Customers.Find(id);
            List<Order> orders = dbcontext.Orders.Where(x => x.CustomerID == id).ToList();
            //--------if customer is in Order list---------
            if (orders.Count > 0)
            {
                ViewBag.Message = "Can't delete, there are orders.";
                return View(customer);
            }
            else
            {
                dbcontext.Customers.Remove(customer);
                dbcontext.SaveChanges();
            }

            return RedirectToAction("Index", collection);

        }
    }
}