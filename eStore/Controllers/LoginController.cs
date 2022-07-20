
using DataAccess.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace eStore.Controllers
{
    public class LoginController : Controller
    {
        IMemberRepository memberRepository = null;
        public LoginController() => memberRepository = new MemberRepository();
        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MembersController/Register
        public ActionResult Register()
        {
            List<Member> members = memberRepository.GetMembers().ToList();
            int id = 1;
            foreach (Member mem in members)
                if (id == mem.MemberId)
                    id++;
            ViewBag.MemberId = id;
            return View();
        }


        // POST: MembersController/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Member member)
        {
            try
            {
                if (ModelState.IsValid)
                    memberRepository.InsertMember(member);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(member);
            }
        }

        // POST: LoginController/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckLogin(Member member)
        {
            try
            {
                var memberList = memberRepository.GetMembers();
                IConfiguration config = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json", true, true)
                                        .Build();
                if (member.Email.Equals(config["Admin:Email"]) && member.Password.Equals(config["Admin:Password"]))
                {
                    HttpContext.Session.SetString("Email", member.Email);
                    return Redirect("../Home/Index");
                }
                else
                {
                    foreach (Member mem in memberList)
                        if (member.Email.Equals(mem.Email) && member.Password.Equals(mem.Password))
                        {
                            HttpContext.Session.SetString("Email", member.Email);
                            return Redirect("../Home/Index");
                        }
                }
                TempData["Email"] = member.Email;
                TempData["Error"] = "Wrong email or password.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Index));
        }

    }
}
