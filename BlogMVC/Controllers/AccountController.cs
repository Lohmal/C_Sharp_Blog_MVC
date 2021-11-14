using BlogMVC.Identity;
using BlogMVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMVC.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private RoleManager<ApplicationRole> roleManager;
        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            userManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            roleManager = new RoleManager<ApplicationRole>(roleStore);
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    UserName = model.UserName,
                    Email = model.Email
                };
                var result = userManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    if (roleManager.RoleExists("user"))
                    {
                        userManager.AddToRole(user.Id, "user");
                    }
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("Hata", "Kullanıcı Oluşturma hatası");
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login model,string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.Find(model.UserName,model.Password);
                if (user!=null)
                {
                    var autManager = HttpContext.GetOwinContext().Authentication;
                    var identityclaims = userManager.CreateIdentity(user, "ApplicationCookie");
                    var autProperties = new AuthenticationProperties() 
                    {
                        IsPersistent = model.RememberMe
                    };                   
                    autManager.SignIn(autProperties, identityclaims);
                    if (ReturnUrl==null)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return Redirect(ReturnUrl);
                    }
                    
                }
               else
                {
                    ModelState.AddModelError("Hata", "Böyle bir kullanıcı yok.");
                }
            }
            
            return View(model);
        }
        public ActionResult LogOut()
        {
            var autManager = HttpContext.GetOwinContext().Authentication;
            autManager.SignOut();
            return RedirectToAction("Index","Home");
        }
        public ActionResult Profil()
        {
            var id = HttpContext.GetOwinContext().Authentication.User.Identity.GetUserId();
            var user = userManager.FindById(id);
            var data = new ProfilGuncelleme()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                UserName = user.UserName
            };
            return View(data);
        }
        [HttpPost]
        public ActionResult Profil(ProfilGuncelleme model)
        {
            var user = userManager.FindById(model.Id);
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.Email = model.Email;
            user.UserName = model.UserName;
            userManager.Update(user);
            return View("Update");
        }
        public ActionResult SifreDegistir()
        {
            
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult SifreDegistir(SifreDegistirme model)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.ChangePassword(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
                return View("Update");
            }
            return View(model);
        }
    }
}