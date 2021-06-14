using Journey.Context;
using Journey.Models;
using Journey.Repositories;
using Journey.ViewModel;
using Journey.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Journey.Controllers
{
    public class UserController : Controller
    {
        UserRepository repository = new UserRepository();

        // GET: User
        public ActionResult Index()
        {
            return RedirectToAction("Login", "Home");
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            if (Session["logged"] != null)
                return RedirectToAction("Login", "Home");
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(RegisterVM model)
        {
         
            if (ModelState.IsValid)
            {
                User data = new User();
                data.FirstName = model.FirstName;
                data.LastName = model.LastName;
                data.Username = model.Username;
                data.Password = model.Password;

                bool isValidUsername = repository.IsValid(data);

                if (isValidUsername != false)
                {
                    ModelState.AddModelError("AuthError", "Username already taken");
                    return RedirectToAction("Create", "User");
                }
                else
                {
                    repository.Add(data);
                    return RedirectToAction("Login", "Home");
                }

            }

            return View();

        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}