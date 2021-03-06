﻿namespace SwitchYourHome.Controllers
{
    using Data;
    using Microsoft.AspNet.Identity;
    using Models;
    using SwitchYourHome.Models.Ads;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;

    public class AdsController : Controller
    {
        //
        //GET : AD
        public ActionResult Index()
        {
            using (var db = new AppDbContext())
            {

                var ads = db.Ads
                    .Include(a => a.Owner)
                    .OrderByDescending(a=>a.Id)
                    .Take(3)
                    .Select(a=>new AdsIndexModel()
                    {
                        Accommodates=a.Accommodates,
                        Bathrooms=a.Bathrooms,
                        Available=a.Available,
                        Bedrooms=a.Bedrooms,
                        Childrens=a.Childrens,
                        ImageUrl=a.ImageUrl,
                        Location=a.Location,
                        Pets=a.Pets,
                        Smoking=a.Smoking,
                        Title=a.Title,
                        Id=a.Id,
                        OwnerId=a.OwnerId
                    })
                    .ToList();

                return View(ads);
            }
        }


        //GET: Ad/List

        public ActionResult List(int page = 1,string search = null, string user = null)
        {
            using (var db = new AppDbContext())
            {
                var pageSize = 4;

                var adsQuery = db.Ads.AsQueryable();

               if(user != null)
                {
                    adsQuery = adsQuery.Where(a => a.Owner.Email == user);
                }

                if (search != null)
                {
                    adsQuery = adsQuery
                        .Where(a => a.Location.ToLower().Contains(search.ToLower()) || a.Title.ToLower().Contains(search.ToLower()));
                }

                var ads = adsQuery
                    .OrderByDescending(a=>a.Id)
                    .Skip((page-1) * pageSize)
                    .Take(pageSize)
                    .Include(a => a.Owner)
                    .Select(a => new AdsIndexModel()
                    {
                        Accommodates = a.Accommodates,
                        Bathrooms = a.Bathrooms,
                        Available = a.Available,
                        Bedrooms = a.Bedrooms,
                        Childrens = a.Childrens,
                        ImageUrl = a.ImageUrl,
                        Location = a.Location,
                        Pets = a.Pets,
                        Smoking = a.Smoking,
                        Title = a.Title,
                        Id = a.Id,
                        OwnerId = a.OwnerId
                    })
                    .ToList();

                ViewBag.CurrentPage = page;

                return View(ads);
            }

        }
        //
        //GET Ad/create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }


        //POST Ad/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(Ad ad)
        {
            if (ModelState.IsValid)
            {
                using (var db = new AppDbContext())
                {
                    var ownerId = db.Users.Where(u => u.UserName == this.User.Identity.Name).First().Id;

                    ad.OwnerId = ownerId;
                    db.Ads.Add(ad);
                    db.SaveChanges();

                    return RedirectToAction("Details", new { id = ad.Id });
                }
            }

            return View(ad);
        }


        //
        //GET: Ad/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var db = new AppDbContext())
            {
                var ad = db.Ads.Where(a => a.Id == id).Include(a => a.Owner).First();

                if (ad == null)
                {
                    return HttpNotFound();
                }

                return View(ad);
            }
        }

        //
        //GET: Ad/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var db = new AppDbContext())
            {
                var ad = db.Ads
                    .Where(a => a.Id == id)
                    .Include(a => a.Owner)
                    .First();

                if (ad == null)
                {
                    return HttpNotFound();
                }

                return View(ad);
            }
        }

        //
        //POST: Ad/Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using(var db=new AppDbContext())
            {
                var ad = db.Ads
                    .Where(a => a.Id == id)
                    .Include(a => a.Owner)
                    .First();

                if (! IsUserAuthorizedToEdit(ad))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                }

                if (ad==null)
                {
                    return HttpNotFound();
                }

                db.Ads.Remove(ad);
                db.SaveChanges();

                return RedirectToAction("List");
            }
        }

        //
        //GET: Ad/Edit
        public ActionResult Edit(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var db= new AppDbContext())
            {
                var ad = db.Ads
                    .Where(a => a.Id == id)
                    .First();

                if (ad==null)
                {
                    return HttpNotFound();
                }

                var model = new AdViewModel();
                model.Accommodates = ad.Accommodates;
                model.Available = ad.Available;
                model.Bathrooms = ad.Bathrooms;
                model.Childrens = ad.Childrens;
                model.Description = ad.Description;
                model.Id = ad.Id;
                model.ImageUrl = ad.ImageUrl;
                model.Location = ad.Location;
                model.Pets = ad.Pets;
                model.Smoking = ad.Smoking;
                model.Title = ad.Title;
                model.Bedrooms = ad.Bedrooms;
                model.OwnerId = ad.OwnerId;

                return View(model);
            }

        }

        //
        //POST: Ad/Edit
        [HttpPost]
        public ActionResult Edit(AdViewModel model)
        {
            if (ModelState.IsValid)
            {
                using(var db=new AppDbContext())
                {
                    var ad = db.Ads.FirstOrDefault(a => a.Id == model.Id);

                    if (!IsUserAuthorizedToEdit(ad))
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                    }

                    ad.Accommodates= model.Accommodates ;
                    ad.Available=model.Available ;
                    ad.Bathrooms= model.Bathrooms;
                    ad.Childrens= model.Childrens;
                    ad.Description= model.Description;
                    ad.ImageUrl= model.ImageUrl;
                    ad.Location= model.Location;
                    ad.Pets= model.Pets;
                    ad.Smoking= model.Smoking;
                    ad.Title= model.Title;
                    ad.Bedrooms= model.Bedrooms;

                    db.Entry(ad).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Details", new { id = model.Id });
                }
            }

            return View(model);
        }

        private bool IsUserAuthorizedToEdit(Ad ad)
        {
            bool isAdmin = this.User.IsInRole("Admin");
            bool isOwner = ad.IsOwner(this.User.Identity.Name);

            return isAdmin || isOwner;
        }
    }
}

