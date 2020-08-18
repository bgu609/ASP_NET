using EddyNewHome.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EddyNewHome.Controllers
{
    public class AdminController : Controller
    {
        EddyHomePageEntities1 db = new EddyHomePageEntities1();
        // GET: Admin
        public ActionResult Index()
        {
            if(Session["user_id"]!=null && Session["user_id"].ToString()=="Admin")
            {
                return View("Index", "_AdminLayout");
            }
            else
            {
                return RedirectToAction("../Home/Index");
            }
        }

        [HttpGet]
        public ActionResult Members()
        {
            IEnumerable<Members> list = db.Members.ToList();
            return View("Members", "_AdminLayout", list);
        }

        [HttpGet]
        public ActionResult MemberEdit(string memberid)
        {
            Members member = db.Members.Find(memberid);
            return View("MemberEdit", "_AdminLayout", member);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Members member)
        {
            Members admin = db.Members.Where(m => m.MemberID == member.MemberID)
                .Where(m => m.MemberPWD == member.MemberPWD)
                .FirstOrDefault();

            if(admin==null)
            {
                ViewBag.Result = "FAIL";
                return View(member);
            }
            else
            {
                Session["user_id"] = admin.MemberID;
                return RedirectToAction("index");
            }
        }

        public ActionResult Logout()
        {
            Session["user_id"] = string.Empty;

            return RedirectToAction("../Home/Index");
        }
    }
}