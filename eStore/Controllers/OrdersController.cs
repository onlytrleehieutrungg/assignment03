using DataAccess.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace eStore.Controllers
{
    public class OrdersController : Controller
    {
        IOrderRepository orderRepository = new OrderRepository();
        IOrderDetailRepository orderdetailRepository = new OrderDetailRepository();
        IMemberRepository memberRepository = new MemberRepository();

        // GET: OrdersController
        public ActionResult Index(string start, string end)
        {
            string LoginEmail = HttpContext.Session.GetString("Email");
            if (LoginEmail == null)
            {
                TempData["Error"] = "Please login!";
                return Redirect("../Login/Index");
            }
            string email = HttpContext.Session.GetString("Email");
            ViewBag.StartDate = start;
            ViewBag.EndDate = end;
            var ordList = orderRepository.GetOrders();            
            if (start != null && end != null)
                ordList = ordList.Where(ord => ord.OrderDate >= DateTime.Parse(start) && ord.OrderDate <= DateTime.Parse(end));       
            return View(ordList);
        }
        public ActionResult MyOrders()
        {
            string LoginEmail = HttpContext.Session.GetString("Email");
            if (LoginEmail == null)
            {
                TempData["Error"] = "Please login!";
                return Redirect("../Login/Index");
            }
            string email = HttpContext.Session.GetString("Email");
            var ordList = orderRepository.GetOrders();
            int memberId = memberRepository.GetMemberByEmail(email).MemberId;
            ordList = orderRepository.GetOrdersByMemberID(memberId);
            return View(ordList);
        }
        

        // GET: OrdersController/Details/5
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
            var orderdetail = orderdetailRepository.GetOrderDetailListByOrder(id.Value);
            if (orderdetail == null)
                return NotFound();
            return View(orderdetail);
        }

        // GET: OrdersController/Create
        public ActionResult Create() => View();

        // POST: OrdersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
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
                    orderRepository.InsertOrder(order);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(order);
            }
        }

        // GET: OrdersController/Edit/5
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
            var order = orderRepository.GetOrderByID(id.Value);
            if (order == null)
                return NotFound();
            return View(order);
        }

        // POST: OrdersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Order order)
        {
            string LoginEmail = HttpContext.Session.GetString("Email");
            if (LoginEmail == null)
            {
                TempData["Error"] = "Please login!";
                return Redirect("../Login/Index");
            }
            try
            {
                if (id != order.OrderId)
                    return NotFound();
                if (ModelState.IsValid)
                    orderRepository.UpdateOrder(order);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        // GET: OrdersController/Delete/5
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
            var order = orderRepository.GetOrderByID(id.Value);
            if (order == null)
                return NotFound();
            return View(order);
        }

        // POST: OrdersController/Delete/5
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
                orderRepository.DeleteOrder(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

    
    }
}
