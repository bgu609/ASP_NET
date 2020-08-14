using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.IO;

using EddyNewHome.Models;
using System.Data.Entity;
using EddyNewHome.Helpers;
using System.Security.Cryptography.X509Certificates;

namespace EddyNewHome.Controllers
{
    public class BoardController : Controller
    {
        EddyHomePageEntities1 db = new EddyHomePageEntities1();
        // GET: Board
        [HttpGet]
        public ActionResult Create()
        {
            BoardArticles articles = new BoardArticles();

            articles.Email = "test@test.com";
            articles.BoardIDX = 2000;

            articles.UserName = "임시사용자";
            articles.IPAddress = Commons.GetIpAddress();
            articles.ViewCnt = 0;
            articles.RegistDate = DateTime.Now;
            articles.RegistUserName = "SYSTEM";

            try
            {
                db.BoardArticles.Add(articles);
                db.SaveChanges();
            }
            catch (Exception)
            {
                //
            }

            return View(articles);
        }

        public ActionResult List()
        {
            List<Members> list = db.Members.OrderByDescending(o => o.EntryDate).ToList();
            return View(list);
        }
    }
}