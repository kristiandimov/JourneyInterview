using Journey.Context;
using Journey.Models;
using Journey.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Journey.Repositories
{
    public class UserRepository : User
    {
        protected DbContext Context { get; set; }
        protected DbSet<User> Items { get; set; }

        public UserRepository()
        {
            Context = new JourneyDbContext();
            Items = Context.Set<User>();
        }

        public void Add(User add)
        {            
           Items.Add(add);
           Context.SaveChanges();                             
        }
             

        public User GetFirstOrDefaut(User item)
        {
            return Items.Where(a => a.Username == item.Username && a.Password == item.Password).FirstOrDefault();
        }
     
        public bool IsValid(User data)
        {
            var user = Items.Where(a => a.Username == data.Username);
            if (user == null)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}