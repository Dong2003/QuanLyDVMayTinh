using PagedList;
using ShopTechOnline.Models;
using ShopTechOnline.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopTechOnline.Controllers
{
    public class NewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: News
        public ActionResult Index(int ? page)
        {
            var pageSize = 4;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<News> items = db.news.Where(x => x.IsActive).Take(12).ToList();
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }

        public ActionResult Detail(int id)
        {
            var items = db.news.Find(id);
            //if (items != null)
            //{
            //    db.news.Attach(items);
            //    items.ViewCount = items.ViewCount + 1;
            //    db.Entry(items).Property(x => x.ViewCount).IsModified = true;
            //    db.SaveChanges();
            //}
            return View(items);
        }

        public ActionResult Parrtial_View_Home() 
        {
            var items = db.news.Take(3).ToList();
            return PartialView(items);
        }
    }
}