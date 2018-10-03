﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MyShop.Core.Contracts;
using MyShop.Core.Model;
using MyShop.DataAccess.InMemory;

namespace MyShop.WebUI.Controllers
{
    public class ProductCategoryManagerController : Controller
    {
        IRepository<ProductCategory> context;

        public ProductCategoryManagerController(IRepository<ProductCategory> productContext)
        {
            context = productContext;
        }

        // GET: ProductManager
        public ActionResult Index()
        {
            List<ProductCategory> productCategories = context.Collection().ToList();
            return View(productCategories);
        }

        public ActionResult Create()
        {
            ProductCategory productCategory = new ProductCategory();
            return View(productCategory);
        }

        [HttpPost]
        public ActionResult Create(ProductCategory productCategories)
        {
            if (!ModelState.IsValid)
            {
                return View(productCategories);
            }
            else
            {
                context.Insert(productCategories);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string id)
        {
            ProductCategory productCategory = context.Find(id);

            if (productCategory == null)
                return HttpNotFound();
            {
                return View(productCategory);
            }
        }

        [HttpPost]
        public ActionResult Edit(ProductCategory productCategory, string id)
        {
            ProductCategory productCategoryToEdit = context.Find(id);

            if (productCategoryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(productCategory);
                }

                productCategoryToEdit.Category = productCategory.Category;

                context.Commit();


                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string id)
        {
            ProductCategory productCategoryToDelete = context.Find(id);

            if (productCategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCategoryToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {
            ProductCategory productCategoryToDelete = context.Find(id);

            if (productCategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(id);
                context.Commit();
                return RedirectToAction("Index");

            }
        }
    }
}