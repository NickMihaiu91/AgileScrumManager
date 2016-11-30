using AgileManager.Web.Models;
using DataLayer.Repositories;
using DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgileManager.Web.Controllers
{
    public class ProductController : Controller
    {
        protected ProductRepository _productRepo;

        public ProductController() : base()
        {
            _productRepo = new ProductRepository();
        }

        //
        // GET: /Product/
        public ActionResult Index()
        {
            var products = _productRepo.GetAll();
            return View(products);
        }

        //
        // GET: /Product/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var product = _productRepo.GetById(id);

                var productModel = new ProductModel()
                {
                    Product = product,
                    AutocompleteModel = new _AutocompleteModel()
                    {
                        UrlAdd = Url.Action("GetAssignTeamToProduct", "Product", new { httproute = "" }),
                        UrlAutocomplete = Url.Action("GetAssignableTeamNamesForProduct", "Product", new { httproute = "" }),
                        UrlDelete = Url.Action("PostUnassignTeam", "Product", new { httproute = "" }),
                        ExistingItems = product.Teams.Select(x => x.Name).ToList(),
                        ProductId = product.Id,
                        AssignPanelHeader = "Assign a team",
                        AssigneesPanelHeader = "Assigned teams"
                    }
                };

                return View(productModel);
            }
            catch(Exception ex)
            {
                return Content("Error: " + ex.Message);
            }
        }

        //
        // GET: /Product/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Product/Create
        [HttpPost]
        public ActionResult Create(Product model)
        {
            try
            {
                if(_productRepo.AddProduct(model))
                    return RedirectToAction("Index");

                // add failed
                ModelState.AddModelError(string.Empty, "Error: Duplicate product names, please choose another name!");
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Product/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _productRepo.GetById(id);
            return View(model);
        }

        //
        // POST: /Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product model)
        {
            try
            {
                if(_productRepo.EditProduct(model))
                    return RedirectToAction("Index");

                ModelState.AddModelError(string.Empty, "Error: Duplicate product names, please choose another name!");
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Product/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _productRepo.DeleteProduct(id);              
            }
            catch
            {               
            }

            return RedirectToAction("Index");
        }

        //
        // GET: /Product/AssignProductOwner/5
        public ActionResult AssignProductOwner(int id)
        {
            try
            {
                var product = _productRepo.GetById(id);

                var productModel = new ProductModel()
                {
                    Product = product,
                    AutocompleteModel = new _AutocompleteModel()
                    {
                        UrlAdd = Url.Action("GetAssignPOToProduct", "User", new { httproute = "", id=product.Id }),
                        UrlAutocomplete = Url.Action("GetAssignableUsersForPO", "User", new { httproute = "", id = product.Id }),
                        UrlDelete = Url.Action("PostUnassignPO", "User", new { httproute = "", id = product.Id }),
                        ExistingItems = product.ProductOwners.Select(x => x.Email).ToList(),
                        AssignPanelHeader = "Assign a product owner",
                        AssigneesPanelHeader = "Assigned product owners",
                        ProductId = product.Id
                    }
                };

                return View(productModel);
            }
            catch (Exception ex)
            {
                return Content("Error: " + ex.Message);
            }
        }

    }
}
