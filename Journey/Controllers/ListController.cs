using Journey.Models;
using Journey.Repositories;
using Journey.ViewModels.Travels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Journey.Controllers
{
    public class ListController : Controller
    {
        // GET: List
        public ActionResult Index(TravelVM model)
        {
            if (Session["logged"] == null)
                return RedirectToAction("Login", "Home");

            if (!ModelState.IsValid)
            {
                return View();
            }

            TravelRepository repo = new TravelRepository();
            User logged = ((User)Session["logged"]);


            model.Items = repo.GetWithoutUsers(logged);

            if (model.SearchByArrival != null || model.SearchByDeparure != null || model.SearchByHourArrival != null || model.SearchByHourDeparure != null)
            {
                HashSet<Travel> set = repo.GetSeach(model, logged);
                model.Items = set.ToList();
            }
            

            return View(model);
            
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