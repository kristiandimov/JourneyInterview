using Journey.Context;
using Journey.Models;
using Journey.ViewModels.Travels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace Journey.Repositories
{
    public class TravelRepository : Travel
    {
        protected DbContext Context { get; set; }
        protected DbSet<Travel> Items { get; set; }

        public TravelRepository()
        {
            Context = new JourneyDbContext();
            Items = Context.Set<Travel>();
        }

        public Travel GetById(int id)
        {
            return Items
                    .Where(i => i.JounrneyId == id)
                    .FirstOrDefault();
        }

        public List<Travel> GetAll(User model)
        {
            return Items
                .Where(a => a.UserId == model.UserId)
                .ToList();
        }

        public List<Travel> GetWithoutUsers(User model)
        {
            return Items
                .Where(a => a.UserId != model.UserId)
                .ToList();
        }

        public HashSet<Travel> GetSeach(TravelVM model, User user)
        {
            HashSet<Travel> items = Items
                .Where(a => a.UserId != user.UserId).ToHashSet();

            if (model.SearchByArrival != null)
            {
                items = items
                .Where(a => a.CityEnd == model.SearchByArrival)
                .ToHashSet();
            }
            
            if(model.SearchByDeparure != null)
            {
                items = items
                .Where(a => a.CityStart == model.SearchByDeparure)
                .ToHashSet();
            }
            
            if (model.SearchByHourArrival != null)
            {
                items = items
                .Where(a => a.HourEnd == model.SearchByHourArrival)
                .ToHashSet();
            }
            
            if (model.SearchByHourDeparure != null)
            {
                items = items
                .Where(a => a.HourStart == model.SearchByHourDeparure)
                .ToHashSet();
            }

            return items;
                
                
        }

        public void Add(Travel item)
        {
            Items.Add(item);
            Context.SaveChanges();
        }

        public void Update(Travel item)
        {
            DbEntityEntry entry = Context.Entry(item);
            entry.State = EntityState.Modified;

            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            Travel item = GetById(id);

            if (item != null)
            {
                Items.Remove(item);
                Context.SaveChanges();
            }
        }

    }
}