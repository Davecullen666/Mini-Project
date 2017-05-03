using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ead_Mini_project_3.Models;
using ead_Mini_project_3.ViewModels;


namespace ead_Mini_project_3.Controllers
{
    public class BandsController : Controller
    {
        private MyDBContext db = new MyDBContext();




        // GET: Bands     
       public ViewResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            var band = from s in db.bands
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                band = band.Where(s => s.BandName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    band = band.OrderBy(s => s.Genres);
                    break;
                case "Date":
                    band = band.OrderBy(s => s.Albums);
                    break;
                case "date_desc":
                    band = band.OrderByDescending(s => s.Genres);
                    break;
                default:
                    band = band.OrderBy(s => s.BandName);
                    break;
            }

            return View(band.ToList());
        }



        //search show details by band name
        public ActionResult SearchBand(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            var band = from s in db.shows
                       select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                band = band.Where(s => s.MainBand.Contains(searchString));
            }

            return View(band.ToList());
        }








        public ActionResult About()
        {
            IQueryable<GenreGroup> data = from Band in db.bands
                                                   group Band by Band.Genres into dateGroup
                                                   select new GenreGroup()
                                                   {
                                                       Genres = dateGroup.Key,
                                                       BandCount = dateGroup.Count()
                                                   };
            return View(data.ToList());
        }



        // GET: Bands/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Band band = db.bands.Find(id);
            if (band == null)
            {
                return HttpNotFound();
            }
            return View(band);
        }

        // GET: Bands/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BandName,Albums,Genres,Members,BandWebsite,Youtube,Contact")] Band band)
        {
            if (ModelState.IsValid)
            {
                db.bands.Add(band);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(band);
        }

        // GET: Bands/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Band band = db.bands.Find(id);
            if (band == null)
            {
                return HttpNotFound();
            }
            return View(band);
        }

        // POST: Bands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BandName,Albums,Genres,Members,BandWebsite,Youtube,Contact")] Band band)
        {
            if (ModelState.IsValid)
            {
                db.Entry(band).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(band);
        }

        // GET: Bands/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Band band = db.bands.Find(id);
            if (band == null)
            {
                return HttpNotFound();
            }
            return View(band);
        }

        // POST: Bands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Band band = db.bands.Find(id);
            db.bands.Remove(band);
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
