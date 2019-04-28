using BusinessLayer;
using BusinessLayer.Impl;
using EntitiesLayer.Concrete;
using EntitiesLayer.ViewObjects;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Web.Mvc;
using PagedList;
using CodeFirstSampleWeb.Models;

namespace CodeFirstSampleWeb.Controllers
{
    public class ProductController : Controller
    {
        IProductBS _productService = new ProductBSImpl();

        // GET: Product
        public ActionResult Index(string pAdi, int? page)
        {
            List<Product> products = new List<Product>();
            if (string.IsNullOrEmpty(pAdi))
            {
                products = _productService.GetProducts();
            } else
            {
                products = _productService.GetProductsByName(pAdi);
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ProductModel model = new ProductModel();
            model.Adi = pAdi;
            model.PagedList = products.ToPagedList(pageNumber, pageSize);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ProductModel model)
        {
            int page = 1;
            List<Product> products = new List<Product>();
            if (!string.IsNullOrEmpty(model.Adi))
            {
                page = 1;
                products = _productService.GetProductsByName(model.Adi);              
            }

            int pageSize = 10;
            int pageNumber = 1;//(page ?? 1);
            model.PagedList = products.ToPagedList(pageNumber,pageSize);
            return View(model);
        }
               
        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _productService.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            PopulateCategoryDropDownList();
            PopulateSupplierDropDownList();
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productService.CreateProduct(product);
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                // Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("",
                    "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }

            PopulateCategoryDropDownList(product.CategoryID);
            PopulateSupplierDropDownList(product.SupplierID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _productService.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            PopulateCategoryDropDownList(product.CategoryID);
            PopulateSupplierDropDownList(product.SupplierID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            PopulateCategoryDropDownList(product.CategoryID);
            PopulateSupplierDropDownList(product.SupplierID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _productService.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _productService.DeleteProduct(id);
            return RedirectToAction("Index");
        }

        // GET: Products/Stats
        // uses the ProductCategoryGroup ViewModel to represent product data 
        public ActionResult Stats(int? id)
        {
            List<ProductCategoryGroup> productCategories = _productService.GetStats();
            return View(productCategories);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        // -----------------------------------------------------------------------------
        // private parts

        private void PopulateCategoryDropDownList(object selectedCategory = null)
        {
            var categories = _productService.GetCategories();
            ViewBag.CategoryID = new SelectList(categories, "CategoryID", "CategoryName", selectedCategory);
        }

        private void PopulateSupplierDropDownList(object selectedSupplier = null)
        {
            var suppliers = _productService.GetSuppliers();
            ViewBag.SupplierID = new SelectList(suppliers, "SupplierID", "CompanyName", selectedSupplier);
        }

    }
}