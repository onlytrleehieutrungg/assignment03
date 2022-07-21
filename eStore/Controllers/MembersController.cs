
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
    public class MembersController : Controller
    {
        IMemberRepository memberRepository = null;
        public MembersController() => memberRepository = new MemberRepository();
        // GET: MembersController
        public ActionResult Index()
        {
            string LoginEmail = HttpContext.Session.GetString("Email");
            if(LoginEmail == null)
            {
                TempData["Error"] = "Please login!";
                return Redirect("../Login/Index");
            }
                
            var memList = memberRepository.GetMembers();
            return View(memList);
        }

        // GET: MembersController/Details/5
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
            var member = memberRepository.GetMemberByID(id.Value);
            if (member == null)
                return NotFound();
            return View(member);
        }

        // GET: MembersController/Create
        public ActionResult Create()
        {
            string LoginEmail = HttpContext.Session.GetString("Email");
            if (LoginEmail == null)
            {
                TempData["Error"] = "Please login!";
                return Redirect("../Login/Index");
            }
            var memberList = memberRepository.GetMembers();
            var memberLast = memberList.Last();
            var member = new Member()
            {
                MemberId = memberLast.MemberId +1
            };
            return View(member);
        } //=> View();

        // POST: MembersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Member member)
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
                    memberRepository.InsertMember(member);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(member);
            }
        }

        // GET: MembersController/Edit/5
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
            var member = memberRepository.GetMemberByID(id.Value);
            if (member == null)
                return NotFound();
            return View(member);
        }

        // POST: MembersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Member member)
        {
            string LoginEmail = HttpContext.Session.GetString("Email");
            if (LoginEmail == null)
            {
                TempData["Error"] = "Please login!";
                return Redirect("../Login/Index");
            }
            try
            {
                if (id != member.MemberId)
                    return NotFound();
                if (ModelState.IsValid)
                    memberRepository.UpdateMember(member);
                if(HttpContext.Session.GetString("Email").Equals("admin@estore.com"))
                    return RedirectToAction(nameof(Index));
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        // GET: MembersController/Delete/5
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
            var member = memberRepository.GetMemberByID(id.Value);
            if (member == null)
                return NotFound();
            return View(member);
        }

        // POST: MembersController/Delete/5
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
                memberRepository.DeleteMember(id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        public ActionResult Profile()
        {
            string LoginEmail = HttpContext.Session.GetString("Email");
            if (LoginEmail == null)
            {
                TempData["Error"] = "Please login!";
                return Redirect("../Login/Index");
            }
            string email = HttpContext.Session.GetString("Email");
            if (email == null)
                return NotFound();
            var member = memberRepository.GetMemberByEmail(email);
            if (member == null)
                return NotFound();
            return View(member);
        }

    }
}
