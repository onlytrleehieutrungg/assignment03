
using DataAccess.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eStore.Controllers
{
    public class ProductsController : Controller
    {
        IProductRepository productRepository = null;
        public ProductsController() => productRepository = new ProductRepository();
        // GET: ProductController
        public ActionResult Index()
        {
            string LoginEmail = HttpContext.Session.GetString("Email");
            if (LoginEmail == null)
            {
                TempData["Error"] = "Please login!";
                return Redirect("../Login/Index");
            }
            var proList = productRepository.GetProducts();
            return View(proList);
        }


        // GET: ProductController/Details/5
        public ActionResult Details(int? id)
        {
            string LoginEmail = HttpContext.Session.GetString("Email");
            if (LoginEmail == null)
            {
                TempData["Error"] = "Please login!";
                return Redirect("../Login/Index");
            }
            if (id == null)
                return NotFound();
            var product = productRepository.GetProductByID(id.Value);
            if (product == null)
                return NotFound();
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create() //=> View();
        {
            string LoginEmail = HttpContext.Session.GetString("Email");
            if (LoginEmail == null)
            {
                TempData["Error"] = "Please login!";
                return Redirect("../Login/Index");
            }
            var proList = productRepository.GetProducts();
            var productLast = proList.Last();
            var product = new Product(){
                ProductId = productLast.ProductId + 1
            };
            return View(product);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            string LoginEmail = HttpContext.Session.GetString("Email");
            if (LoginEmail == null)
            {
                TempData["Error"] = "Please login!";
                return Redirect("../Login/Index");
            }
            try
            {
                if (ModelState.IsValid)
                    productRepository.InsertProduct(product);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(product);
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int? id)
        {
            string LoginEmail = HttpContext.Session.GetString("Email");
            if (LoginEmail == null)
            {
                TempData["Error"] = "Please login!";
                return Redirect("../Login/Index");
            }
            if (id == null)
                return NotFound();
            var product = productRepository.GetProductByID(id.Value);
            if (product == null)
                return NotFound();
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product)
        {
            string LoginEmail = HttpContext.Session.GetString("Email");
            if (LoginEmail == null)
            {
                TempData["Error"] = "Please login!";
                return Redirect("../Login/Index");
            }
            try
            {
                if (id != product.ProductId)
                    return NotFound();
                if (ModelState.IsValid)
                    productRepository.UpdateProduct(product);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int? id)
        {
            string LoginEmail = HttpContext.Session.GetString("Email");
            if (LoginEmail == null)
            {
                TempData["Error"] = "Please login!";
                return Redirect("../Login/Index");
            }
            if (id == null)
                return NotFound();
            var product = productRepository.GetProductByID(id.Value);
            if (product == null)
                return NotFound();
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            string LoginEmail = HttpContext.Session.GetString("Email");
            if (LoginEmail == null)
            {
                TempData["Error"] = "Please login!";
                return Redirect("../Login/Index");
            }
            try
            {
                productRepository.DeleteProduct(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        // GET: ProductController/Search/5

        public ActionResult Search(string name, string price)
        {
            string LoginEmail = HttpContext.Session.GetString("Email");
            if (LoginEmail == null)
            {
                TempData["Error"] = "Please login!";
                return Redirect("../Login/Index");
            }
            ViewBag.Search = name;
            ViewBag.Price = price;
            var products = productRepository.GetProducts();
            var result = products;
            if (name == null && price != null)
            {
                if (price == "<1000$")
                    result = products.Where(p => p.UnitPrice <= 1000);
                if (price == "1000-5000$")
                    result = products.Where(p => p.UnitPrice >= 1000 && p.UnitPrice <= 5000);
                if (price == "5000-10000$")
                    result = products.Where(p => p.UnitPrice >= 5000 && p.UnitPrice <= 10000);
                if (price == ">10000$")
                    result = products.Where(p => p.UnitPrice >= 10000);
            }
                
            if(name != null && price == null)
            {
                result = products.Where(p => p.ProductName.ToLower().Contains(name));
            }
            if(name != null && price != null)
            {
                result = products.Where(p => p.ProductName.ToLower().Contains(name));
                if (price == "<1000$")
                    result = result.Where(p => p.UnitPrice <= 1000);
                if (price == "1000-5000$")
                    result = result.Where(p => p.UnitPrice >= 1000 && p.UnitPrice <= 5000);
                if (price == "5000-10000$")
                    result = result.Where(p => p.UnitPrice >= 5000 && p.UnitPrice <= 10000);
                if (price == ">10000$")
                    result = result.Where(p => p.UnitPrice >= 10000);
            }    
            
            return View(result);
        }


    }
}
