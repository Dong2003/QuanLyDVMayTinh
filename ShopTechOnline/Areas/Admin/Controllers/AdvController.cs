using PagedList;
using ShopTechOnline.Models;
using ShopTechOnline.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopTechOnline.Areas.Admin.Controllers
{
    public class AdvController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Adv
        public ActionResult Index( int ? page)
        {
            IEnumerable<Adv> items = db.advs.OrderByDescending(x => x.ID);
            var pageSize = 8;
            if (page == null)
            {
                page = 1;
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Adv model) {
            if (ModelState.IsValid) 
            {
                model.CreatedDate = DateTime.Now;
                model.ModifiledDate = DateTime.Now;
                model.Alias = ShopTechOnline.Models.Common.FIlter.FilterChar(model.Title);
                db.advs.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit( int id)
        {
            var items = db.advs.Find(id);
            return View(items);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Adv model) 
        {
            if (ModelState.IsValid)
            {
                model.ModifiledDate = DateTime.Now;
                model.Alias = ShopTechOnline.Models.Common.FIlter.FilterChar(model.Title);
                db.advs.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return Edit(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var items = db.advs.Find(id);
            if (items != null)
            {
                db.advs.Remove(items);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult DeleteAll(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                // tach chuoi ids thanh cac mang chuoi con 
                var items = ids.Split(',');
                if (items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        var obj = db.advs.Find(Convert.ToInt32(item));
                        db.advs.Remove(obj);
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}