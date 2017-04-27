namespace SwitchYourHome.Controllers.Admin
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using SwitchYourHome.Data;
    using SwitchYourHome.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;

    [Authorize(Roles ="Admin")]
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: User/List
        public ActionResult List()
        {
            using (var db = new AppDbContext())
            {
                var users = db.Users.ToList();

                var admins = GetAdmins(db);
                ViewBag.Admins = admins;

                return View(users);
            }
        }

        //
        // GET: User/Edit
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var db = new AppDbContext())
            {
                var user = db.Users.Where(u => u.Id == id).First();

                if (user == null)
                {
                    return HttpNotFound();
                }

                var viewModel = new EditUserViewModel();
                viewModel.User = user;
                viewModel.Roles = GetUserRoles(user, db);

                return View(viewModel);
            }
        }

        //
        // POST: User/Edit
        [HttpPost]
        public ActionResult Edit(string id, EditUserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                using (var db = new AppDbContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.Id == id);

                    if (user == null)
                    {
                        return HttpNotFound();
                    }

                    if (!string.IsNullOrEmpty(viewModel.Password))
                    {
                        var passwordHasher = new PasswordHasher();
                        var newPasswordHash = passwordHasher.HashPassword(viewModel.Password);
                        user.PasswordHash = newPasswordHash;
                    }

                    user.Email = viewModel.User.Email;
                    user.FullName = viewModel.User.FullName;
                    user.UserName = viewModel.User.Email;

                    this.SetUserRoles(viewModel, user, db);

                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("List");
                }
            }

            return View(viewModel);
        }

        //
        // GET: User/Delete
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var db = new AppDbContext())
            {
                var user = db.Users.Where(u => u.Id == id).First();

                if (user == null)
                {
                    return HttpNotFound();
                }



                return View(user);
            }
        }

        //
        //POST: User/Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using( var db=new AppDbContext())
            {
                var user = db.Users.Where(u => u.Id.Equals(id)).First();

                var userAds = db.Ads.Where(a => a.Owner.Id == user.Id);

                foreach (var ad in userAds)
                {
                    db.Ads.Remove(ad);
                }

                db.Users.Remove(user);
                db.SaveChanges();


                return RedirectToAction("List");
            }
        }

        private void SetUserRoles(EditUserViewModel viewModel, ApplicationUser user, AppDbContext db)
        {
            var userManager = Request
                 .GetOwinContext()
                 .GetUserManager<ApplicationUserManager>();

            foreach (var role in viewModel.Roles)
            {
                if (role.IsSelected)
                {
                    userManager.AddToRole(user.Id, role.Name);
                }
                else if (!role.IsSelected)
                {
                    userManager.RemoveFromRole(user.Id, role.Name);
                }
            }
        }

        private List<Role> GetUserRoles(ApplicationUser user, AppDbContext db)
        {
            var userManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var roles = db.Roles.Select(r => r.Name).OrderBy(r => r).ToList();

            var userRoles = new List<Role>();

            foreach (var roleName in roles)
            {
                var role = new Role { Name = roleName };

                if (userManager.IsInRole(user.Id, roleName))
                {
                    role.IsSelected = true;
                }

                userRoles.Add(role);
            }

            return userRoles;
        }

        private HashSet<string> GetAdmins(AppDbContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            var users = db.Users.ToList();

            var admins = new HashSet<string>();

            foreach (var user in users)
            {
                if (userManager.IsInRole(user.Id, "Admin"))
                {
                    admins.Add(user.Id);
                }
            }

            return admins;
        }
    }
}