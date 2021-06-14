using Journey.Context;
using Journey.Models;
using Journey.Repositories;
using Journey.ViewModels.Travels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace Journey.Controllers
{
    public class TravelController : Controller
    {
        
        // GET: Travel       
        public ActionResult Index(TravelVM model)
        {
            if (Session["logged"] == null)
                return RedirectToAction("Login", "Home");

            TravelRepository repo = new TravelRepository();
            User logged = (User)Session["logged"];

            model.Items = repo.GetAll(logged);

            return View(model);
        }

        
        [HttpGet]
        public ActionResult Create()
        {
            if (Session["logged"] == null)
                return RedirectToAction("Login", "Home");
            return View();
        }

        [HttpPost]
        public ActionResult Create(TravelVM model)
        {
           
            Travel travel = new Travel();
            travel.JounrneyId = model.JounrneyId;
            travel.UserId = ((User)Session["logged"]).UserId;
            travel.CityStart = model.CityStart;
            travel.CityEnd = model.CityEnd;
            travel.AddressStart = model.AddressStart;
            travel.AddressEnd = model.AddressEnd;
            travel.HourStart = model.HourStart;
            travel.HourEnd = model.HourEnd;
            travel.Price = model.Price;
            travel.FreeSpace = model.FreeSpace;

            TravelRepository repo = new TravelRepository();

            repo.Add(travel);


            return RedirectToAction("Index","Travel");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["logged"] == null)
                return RedirectToAction("Login", "Home");

            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Travel");
            }

            TravelRepository repo = new TravelRepository();
            Travel travel = repo.GetById(id);

            if (travel.UserId != ((User)Session["logged"]).UserId)
            {
                return RedirectToAction("Login", "Home");
            }

            TravelVM model = new TravelVM();
            model.JounrneyId = travel.JounrneyId;
            model.CityStart = travel.CityStart;
            model.CityEnd = travel.CityEnd;
            model.AddressStart = travel.AddressStart;
            model.AddressEnd = travel.AddressEnd;
            model.HourStart = travel.HourStart;
            model.HourEnd = travel.HourEnd;
            model.Price = travel.Price;
            model.FreeSpace = travel.FreeSpace;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(TravelVM model)
        {
            if (Session["logged"] == null)
                return RedirectToAction("Login", "Home");

            if(!ModelState.IsValid)
            {
                return View(model);             
            }

            Travel travel = new Travel();

            travel.JounrneyId = model.JounrneyId;
            travel.UserId = ((User)Session["logged"]).UserId;
            travel.CityStart = model.CityStart;
            travel.CityEnd = model.CityEnd;
            travel.AddressStart = model.AddressStart;
            travel.AddressEnd = model.AddressEnd;
            travel.HourStart = model.HourStart;
            travel.HourEnd = model.HourEnd;
            travel.Price = model.Price;
            travel.FreeSpace = model.FreeSpace;

            TravelRepository repo = new TravelRepository();
            repo.Update(travel);

         
            return RedirectToAction("Index", "Travel");

        }

        public ActionResult Delete(int id)
        {
            if (Session["logged"] == null)
                return RedirectToAction("Login", "Home");

            if (!ModelState.IsValid)
            {
                return View();
            }

            TravelRepository repo = new TravelRepository();
            repo.Delete(id);

            return RedirectToAction("Index", "Travel");
        }

        public ActionResult Details(int id)
        {
            if (Session["logged"] == null)
                return RedirectToAction("Login", "Home");

            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            TravelRepository repo = new TravelRepository();
            Travel travel = repo.GetById(id);
            TravelVM model = new TravelVM();

            model.User = travel.User;
            model.CityStart = travel.CityStart;
            model.CityEnd = travel.CityEnd;
            model.AddressStart = travel.AddressStart;
            model.AddressEnd = travel.AddressEnd;
            model.HourStart = travel.HourStart;
            model.HourEnd = travel.HourEnd;
            model.Price = travel.Price;
            model.FreeSpace = travel.FreeSpace;


            return View(model);
        }
    }
}