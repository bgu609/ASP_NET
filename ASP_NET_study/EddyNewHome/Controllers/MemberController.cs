using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EddyNewHome.Models;
using System.Data.Entity;

namespace EddyNewHome.Controllers
{
    public class MemberController : Controller
    {
        EddyHomePageEntities1 db = new EddyHomePageEntities1();
        // GET: Member
        public ActionResult Entry()
        {
            Members members = new Members();
            return View(members);
        }

        public ActionResult List()
        {
            List<Members> list = db.Members.OrderByDescending(o => o.EntryDate).ToList();
            return View(list);
        }
    }
}