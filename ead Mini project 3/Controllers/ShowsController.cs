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
    public class ShowsController : Controller
    {
        private MyDBContext db = new MyDBContext();

        // GET: Shows  Search by show name
        public ViewResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            var show = from s in db.shows
                       select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                show = show.Where(s => s.ShowName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    show = show.OrderBy(s => s.ShowName);
                    break;
                case "Date":
                    show = show.OrderBy(s => s.Time);
                    break;
                case "date_desc":
                    show = show.OrderByDescending(s => s.Venue);
                    break;
                default:
                    show = show.OrderBy(s => s.Time);
                    break;
            }

            return View(show.ToList());
        }



        //search show details by Venue name
        public ActionResult SearchVenue(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            var show = from s in db.shows
                       select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                show = show.Where(s => s.Venue.Contains(searchString));
            }

            return View(show.ToList());
        }



        //about section to tell number of shows on dates
        public ActionResult About()
        {
            IQueryable<GigsPerDay> data = from Show in db.shows
                                          group Show by Show.Time into dateGroup
                                          select new GigsPerDay()
                                          {
                                              Time = dateGroup.Key,
                                              GigCount = dateGroup.Count()
                                          };
            return View(data.ToList());
        }




        // GET: Shows/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Show show = db.shows.Find(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            return View(show);
        }

        // GET: Shows/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ShowName,Venue,Time,Price,MainBand,SupportBand,TicketsAvailable,SoldOut")] Show show)
        {
            if (ModelState.IsValid)
            {
                db.shows.Add(show);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(show);
        }

        // GET: Shows/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Show show = db.shows.Find(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            return View(show);
        }

        // POST: Shows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ShowName,Venue,Time,Price,MainBand,SupportBand,TicketsAvailable,SoldOut")] Show show)
        {
            if (ModelState.IsValid)
            {
                db.Entry(show).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(show);
        }

        // GET: Shows/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Show show = db.shows.Find(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            return View(show);
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Show show = db.shows.Find(id);
            db.shows.Remove(show);
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
