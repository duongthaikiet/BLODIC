using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Web.Mvc;
using DuongThaiKiet.DTKEF;
using DuongThaiKiet.Enum;
using DuongThaiKiet.Utility;

namespace DuongThaiKiet.Areas.Blog.Controllers
{
    public class DescendingComparer<T> : Comparer<T>
    {
        public override int Compare(T x, T y)
        {
            return Comparer<T>.Default.Compare(y, x);
        }
    }

    public class BlogEntriesController : Controller
    {
        private DTKEntities db = new DTKEntities();


        // GET: Blog/BlogEntries
        public ActionResult Index(string sortingColume, int limit = 10)
        {
            if (sortingColume == null)
            {
                sortingColume = string.Empty;
            }

            Func<BlogEntryModel, Object> orderColumeFunc =
                item => item.GetType().GetProperty(sortingColume) == null ?
                        item.Id : 
                        item.GetType().GetProperty(sortingColume).GetValue(item, null);

            var blogEntries = db.BlogEntries.Select(b => new BlogEntryModel
            {
                Id = b.Id,
                Title = b.Title,
                UserId = b.UserId,
                UserName = b.AdminUser.UserName
            }).AsEnumerable().OrderBy(orderColumeFunc).Take(limit);

            return View(blogEntries);
        }

        // GET: Blog/BlogEntries/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogEntry blogEntry = db.BlogEntries.Find(id);
            
            if (blogEntry == null)
            {
                return HttpNotFound();
            }
            return View(blogEntry);
        }

        // GET: Blog/BlogEntries/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.AdminUsers, "Id", "UserName");
            return View();
        }

        // POST: Blog/BlogEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //TODO: Remove field that has default value that was set in SQL database (e.g. DateCreated, DateModified)
        public ActionResult Create([Bind(Include = "Id,Title,Summary,DateCreated,DateModified,UserId,Content,ImageURL")] BlogEntry blogEntry)
        {
            if (ModelState.IsValid)
            {
                blogEntry.DateCreated = DateTime.Now;
                db.BlogEntries.Add(blogEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.AdminUsers, "Id", "UserName", blogEntry.UserId);
            return View(blogEntry);
        }

        // GET: Blog/BlogEntries/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogEntry blogEntry = db.BlogEntries.Find(id);
            if (blogEntry == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.AdminUsers, "Id", "UserName", blogEntry.UserId);
            return View(blogEntry);
        }

        // POST: Blog/BlogEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // TODO: ValidateInput(false): Allow cross site scripting attack (e.g. allow HTML tags to be inserted/updated to database)
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Summary,DateCreated,DateModified,UserId,Content,ImageURL")] BlogEntry blogEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
			ViewBag.DateOfBirth = new DateTime(1989, 1, 9);
            ViewBag.UserId = new SelectList(db.AdminUsers, "Id", "UserName", blogEntry.UserId);
            return View(blogEntry);
        }

        // GET: Blog/BlogEntries/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogEntry blogEntry = db.BlogEntries.Find(id);
            if (blogEntry == null)
            {
                return HttpNotFound();
            }
            return View(blogEntry);
        }

        // POST: Blog/BlogEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            BlogEntry blogEntry = db.BlogEntries.Find(id);
            db.BlogEntries.Remove(blogEntry);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public JsonResult BlogPreview(BlogEntryModel blogModel)
        {
            if (blogModel.Id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogEntry blogEntry = db.BlogEntries.Find(blogModel.Id);
            if (blogEntry == null)
            {
                return Json("Oops! We're unable to find this blog. It may be deleted or you can come back later");
            }

            //System.Threading.Thread.Sleep(5000);

            return Json(new BlogEntryModel
            {
                Id = blogEntry.Id,
                Title = blogEntry.Title,
                DateCreated = blogEntry.DateCreated,
                UserName = blogEntry.AdminUser.UserName,
                Summary = blogEntry.Summary
            });
        }
    }
}
