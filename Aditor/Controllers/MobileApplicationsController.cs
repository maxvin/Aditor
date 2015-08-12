using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Aditor;
using Aditor.Models;

namespace Aditor.Controllers
{
    using Aditor.Models.ViewModels;

    public class MobileApplicationsController : Controller
    {
        private AditorDb db = new AditorDb();

        // GET: MobileApplications
        public ActionResult Index()
        {
            return View(db.MobileApplications.ToList());
        }

        // GET: MobileApplications/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MobileApplication mobileApplication = db.MobileApplications.Find(id);
            if (mobileApplication == null)
            {
                return HttpNotFound();
            }
            return View(mobileApplication);
        }

        // GET: MobileApplications/Create
        public ActionResult Create()
        {
            MobileApplicationViewModel mavm = new MobileApplicationViewModel();
            mavm.AllAffiliates = db.Affiliates.ToList();
            mavm.AllCampaignes = db.Campaignes.ToList();
            return View(mavm);
        }

        // POST: MobileApplications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MobileApplicationViewModel mobileApplication)
        {
            if (ModelState.IsValid)
            {
                var app = ConvertApplicationModel(mobileApplication);
                db.MobileApplications.Add(app);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mobileApplication);
        }

        // GET: MobileApplications/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MobileApplication mobileApplication = db.MobileApplications.Find(id);
            if (mobileApplication == null)
            {
                return HttpNotFound();
            }
            return View(mobileApplication);
        }

        // POST: MobileApplications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PackageName,Id")] MobileApplication mobileApplication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mobileApplication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mobileApplication);
        }

        // GET: MobileApplications/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MobileApplication mobileApplication = db.MobileApplications.Find(id);
            if (mobileApplication == null)
            {
                return HttpNotFound();
            }
            return View(mobileApplication);
        }

        // POST: MobileApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MobileApplication mobileApplication = db.MobileApplications.Find(id);
            db.MobileApplications.Remove(mobileApplication);
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

        private MobileApplication ConvertApplicationModel(MobileApplicationViewModel model)
        {
            MobileApplication res = new MobileApplication();
            res.Id = model.Id;
            res.PackageName = model.PackageName;
            res.Owner = db.Affiliates.Find(model.AffilateId);
            res.AdCampaign = db.Campaignes.Find(model.CampaignId);
            return res;
        }
    }
}
