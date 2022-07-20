
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
    public class OrderDetailsController : Controller
    {
        IOrderDetailRepository orderdetailRepository = null;
        public OrderDetailsController() => orderdetailRepository = new OrderDetailRepository();
        // GET: OrderDetailsController
        public ActionResult Index()
        {
            string LoginEmail = HttpContext.Session.GetString("Email");
            if (LoginEmail == null)
            {
                TempData["Error"] = "Please login!";
                return Redirect("../Login/Index");
            }
            return View();
        }

        // GET: OrderDetailsController/Details/5
        public ActionResult Details(int? ordid, int? proid)
        {
            string LoginEmail = HttpContext.Session.GetString("Email");
            if (LoginEmail == null)
            {
                TempData["Error"] = "Please login!";
                return Redirect("../Login/Index");
            }
            if (ordid == null && proid == null)
                return NotFound();
            var order = orderdetailRepository.GetOrderDetailByOrderAndProduct(ordid.Value, proid.Value);
            if (order == null)
                return NotFound();
            return View(order);
        }

        // GET: OrderDetailsController/Create
        public ActionResult Create(string orderid)
        {
            string LoginEmail = HttpContext.Session.GetString("Email");
            if (LoginEmail == null)
            {
                TempData["Error"] = "Please login!";
                return Redirect("../Login/Index");
            }
            HttpContext.Session.SetString("OrderID", orderid);
            return View();
        }

        // POST: OrderDetailsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderDetail orderdetail)
        {
            string LoginEmail = HttpContext.Session.GetString("Email");
            if (LoginEmail == null)
            {
                TempData["Error"] = "Please login!";
                return Redirect("../Login/Index");
            }
            try
            {
                orderdetailRepository.InsertOrderDetail(orderdetail);
                return RedirectToAction(actionName: "Index",controllerName: "Orders");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(orderdetail);
            }
        }

        // GET: OrderDetailsController/Edit/5
        public ActionResult Edit(int? ordid, int? proid)
        {
            string LoginEmail = HttpContext.Session.GetString("Email");
            if (LoginEmail == null)
            {
                TempData["Error"] = "Please login!";
                return Redirect("../Login/Index");
            }
            if (ordid == null && proid == null)
                return NotFound();
            var orderdetail = orderdetailRepository.GetOrderDetailByOrderAndProduct(ordid.Value, proid.Value);
            if (orderdetail == null)
                return NotFound();
            return View(orderdetail);
        }

        // POST: OrderDetailsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int ordid, int proid, OrderDetail orderdetail)
        {
            string LoginEmail = HttpContext.Session.GetString("Email");
            if (LoginEmail == null)
            {
                TempData["Error"] = "Please login!";
                return Redirect("../Login/Index");
            }
            try
            {
                orderdetailRepository.UpdateOrderDetail(orderdetail);
                return RedirectToAction(actionName: "Details", controllerName: "Orders", routeValues: ordid);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(orderdetail);
            }
        }

        // GET: OrderDetailsController/Delete/5
        public ActionResult Delete(int? ordid, int? proid)
        {
            string LoginEmail = HttpContext.Session.GetString("Email");
            if (LoginEmail == null)
            {
                TempData["Error"] = "Please login!";
                return Redirect("../Login/Index");
            }
            if (ordid == null)
                return NotFound();
            var orderdetail = orderdetailRepository.GetOrderDetailByOrderAndProduct(ordid.Value, proid.Value);
            if (orderdetail == null)
                return NotFound();
            return View(orderdetail);
        }

        // POST: OrderDetailsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int ordid, int proid, OrderDetail orderdetail)
        {
            string LoginEmail = HttpContext.Session.GetString("Email");
            if (LoginEmail == null)
            {
                TempData["Error"] = "Please login!";
                return Redirect("../Login/Index");
            }
            try
            {
                if (ordid != orderdetail.OrderId || proid != orderdetail.ProductId)
                    return NotFound();
                if (ModelState.IsValid)
                orderdetailRepository.DeleteOrderDetail(ordid, proid);
                return RedirectToAction(actionName: "Index", controllerName: "Orders");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }
    }
}
