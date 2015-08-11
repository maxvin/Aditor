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
    public class RulesController : Controller
    {
        private AditorDb db = new AditorDb();

        // GET: Rules
        public ActionResult Index(int campaignId)
        {
            var campaign = db.Campaignes.Find(campaignId);
            var rules = campaign.Rules;
            return View(rules);
        }

        // GET: Rules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rules rules = db.Rules.Find(id);
            if (rules == null)
            {
                return HttpNotFound();
            }
            return View(rules);
        }

        // GET: Rules/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RuleId,GeoTag,Offers,RuleIsDefault,RuleDescription")] Rules rules)
        {
            if (ModelState.IsValid)
            {
                db.Rules.Add(rules);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rules);
        }

        // GET: Rules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rules rules = db.Rules.Find(id);
            if (rules == null)
            {
                return HttpNotFound();
            }
            return View(rules);
        }

        // POST: Rules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RuleId,GeoTag,Offers,RuleIsDefault,RuleDescription")] Rules rules)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rules).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rules);
        }

        // GET: Rules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rules rules = db.Rules.Find(id);
            if (rules == null)
            {
                return HttpNotFound();
            }
            return View(rules);
        }

        // POST: Rules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rules rules = db.Rules.Find(id);
            db.Rules.Remove(rules);
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
