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
    using Aditor.Models.ViewModels;

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

            Offer offer = db.Offers.Find(id);
            if (offer.Type == OfferType.Banner)
            {
                offer = db.Banners.Find(id);
            }

            if (offer == null)
            {
                return HttpNotFound();
            }

            return View(offer);
        }

        // GET: Offers/Create
        public ActionResult Create()
        {
            var offerVM = new OfferViewModel();

            offerVM.Advertisers = db.Advertisers.ToList();
            offerVM.Categories = db.Categories.ToList();
            offerVM.DealsList = db.Deals.ToList();

            return View(offerVM);
        }

        // POST: Offers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="offer">
        /// The offer.
        /// </param>
        /// <param name="uploadBanner">
        /// The upload banner.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OfferViewModel offerVM, HttpPostedFileBase uploadBanner)
        {
            if (this.ModelState.IsValid)
            {

                Offer offer = GetOffer(offerVM);

                if (offer.Type == OfferType.Banner)
                {
                    if (uploadBanner != null && uploadBanner.ContentLength > 0)
                    {
                        var newBanner = new Banner(offer)
                        {
                            FileName = System.IO.Path.GetFileName(uploadBanner.FileName),
                            ContentType = uploadBanner.ContentType
                        };

                        using (var reader = new System.IO.BinaryReader(uploadBanner.InputStream))
                        {
                            newBanner.Content = reader.ReadBytes(uploadBanner.ContentLength);
                        }

                        this.db.Banners.Add(newBanner);
                        this.db.SaveChanges();
                        return this.RedirectToAction("Index");
                    }
                }

                this.db.Offers.Add(offer);
                this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View(offerVM);
        }

        private Offer GetOffer(OfferViewModel offerVm)
        {
            var res = new Offer();
            res.Type = offerVm.Type;
            res.active = offerVm.active;
            res.advertiser = db.Advertisers.Find(offerVm.advertiserId);
            res.category = db.Categories.Find(offerVm.categoryId);
            res.lp = offerVm.lp;
            res.offerID = offerVm.offerID;
            res.offername = offerVm.offername;
            res.payouttype = db.Deals.Find(offerVm.payouttypeId);
            res.payoutvalue = offerVm.payoutvalue;
            res.revenuetype = db.Deals.Find(offerVm.revenuetypeId);
            res.revenuevalue = offerVm.revenuevalue;
            res.staticvalues = offerVm.staticvalues;
            return res;
        }

        // GET: Offers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offer offer = db.Offers.Find(id);
            if (offer == null)
            {
                return HttpNotFound();
            }
            var offerVM = new OfferViewModel(offer);
            offerVM.Advertisers = db.Advertisers.ToList();
            offerVM.Categories = db.Categories.ToList();
            offerVM.DealsList = db.Deals.ToList();

            return View(offerVM);
        }

        // POST: Offers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "offerID,advertiserID,lp,category,revenuetype,revenuevalue,payouttype,payoutvalue,active,staticvalues,offername")] Offer offer, HttpPostedFileBase uploadBanner)
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
                
                //db.Offers.Add(offer);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(offer);
        }

        // GET: Offers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offer offer = db.Offers.Find(id);
            if (offer == null)
            {
                return HttpNotFound();
            }
            return View(offer);
        }

        // POST: Offers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Offer offer = db.Offers.Find(id);
            db.Offers.Remove(offer);
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
