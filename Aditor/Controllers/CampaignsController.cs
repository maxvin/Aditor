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
    public class CampaignsController : Controller
    {
        private AditorDb db = new AditorDb();

        // GET: Campaignes
        public ActionResult Index()
        {
            return View(db.Campaignes.ToList());
        }

        // GET: Campaignes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campaignes campaignes = db.Campaignes.Find(id);
            if (campaignes == null)
            {
                return HttpNotFound();
            }
            return View(campaignes);
        }

        // GET: Campaignes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Campaignes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CampaignId,CampaignName,CampaignIsDefault,CampaignDescription")] Campaignes campaignes)
        {
            if (ModelState.IsValid)
            {
                db.Campaignes.Add(campaignes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(campaignes);
        }

        // GET: Campaignes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campaignes campaignes = db.Campaignes.Find(id);
            if (campaignes == null)
            {
                return HttpNotFound();
            }
            return View(campaignes);
        }

        // POST: Campaignes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CampaignId,CampaignName,CampaignIsDefault,CampaignDescription")] Campaignes campaignes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(campaignes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(campaignes);
        }

        // GET: Campaignes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campaignes campaignes = db.Campaignes.Find(id);
            if (campaignes == null)
            {
                return HttpNotFound();
            }
            return View(campaignes);
        }

        // POST: Campaignes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Campaignes campaignes = db.Campaignes.Find(id);
            db.Campaignes.Remove(campaignes);
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
