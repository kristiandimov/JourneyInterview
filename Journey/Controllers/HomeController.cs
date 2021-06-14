using Journey.Models;
using Journey.Repositories;
using Journey.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Journey.Controllers
{
    public class HomeController : Controller
    {
        public UserRepository repository = new UserRepository();

        public ActionResult Index()
        {
            if (Session["logged"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }            
        }

        public ActionResult Create()
        {
            return RedirectToAction("Create", "User");
        }


        [HttpGet]
        public ActionResult Login()
        {
            if (Session["logged"] != null)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM model)
        {

            if (ModelState.IsValid)
            {
                User data = new User();
                data.Username = model.Username;
                data.Password = model.Password;
                User logged = repository.GetFirstOrDefaut(data);


                if (logged == null)
                {
                    ModelState.AddModelError("AuthError", "Wrong username password");
                }
                else
                {
                    Session["logged"] = logged;
                }
               
            }

            if (!ModelState.IsValid)
                return View(model);


            return RedirectToAction("Index", "Travel");
                    
        }

        public ActionResult Logout()
        {
            Session["logged"] = null;
            return RedirectToAction("Login","Home");
        }


        public ActionResult About()
        {
            if (Session["logged"] == null)
                return RedirectToAction("Login", "Home");

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }


}