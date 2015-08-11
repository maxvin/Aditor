using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Aditor;

namespace Aditor.Controllers
{
    using Aditor.Models;

    public class OffersController : Controller
    {
        private AditorDb db = new AditorDb();

        // GET: Offers
        public ActionResult Index()
        {
            return View(db.Offers.ToList());
        }

        // GET: Offers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Offers offers = db.Offers.Find(id);
            if (offers == null)
            {
                return HttpNotFound();
            }

            return View(offers);
        }

        // GET: Offers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Offers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "offerID,advertiserID,lp,category,revenuetype,revenuevalue,payouttype,payoutvalue,active,staticvalues,offername")] Offers offers, HttpPostedFileBase uploadBanner)
        {
            if (ModelState.IsValid)
            {
                if (uploadBanner != null && uploadBanner.ContentLength > 0)
                {
                    var newBanner = new Banner
                    {
                        FileName = System.IO.Path.GetFileName(uploadBanner.FileName),
                        ContentType = uploadBanner.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(uploadBanner.InputStream))
                    {
                        newBanner.Content = reader.ReadBytes(uploadBanner.ContentLength);
                    }

                    //offers.Banner = newBanner;
                }

                db.Offers.Add(offers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(offers);
        }

        // GET: Offers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offers offers = db.Offers.Find(new object() );
            if (offers == null)
            {
                return HttpNotFound();
            }
            return View(offers);
        }

        // POST: Offers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "offerID,advertiserID,lp,category,revenuetype,revenuevalue,payouttype,payoutvalue,active,staticvalues,offername")] Offers offers, HttpPostedFileBase uploadBanner)
        {
            if (ModelState.IsValid)
            {
                //if (uploadBanner != null && uploadBanner.ContentLength > 0)
                //{
                //    if (offers.Banner != null)
                //    {
                //        db.Banners.Remove(offers.Banner);
                //    }
                //    var newBanner = new Banner
                //    {
                //        FileName = System.IO.Path.GetFileName(uploadBanner.FileName),
                //        ContentType = uploadBanner.ContentType
                //    };
                //    using (var reader = new System.IO.BinaryReader(uploadBanner.InputStream))
                //    {
                //        newBanner.Content = reader.ReadBytes(uploadBanner.ContentLength);
                //    }

                //    offers.Banner = newBanner;
                //}

                //db.Entry(offers).State = EntityState.Modified;
                
                db.Offers.Add(offers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(offers);
        }

        // GET: Offers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offers offers = db.Offers.Find(id);
            if (offers == null)
            {
                return HttpNotFound();
            }
            return View(offers);
        }

        // POST: Offers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Offers offers = db.Offers.Find(id);
            db.Offers.Remove(offers);
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
    }
}
