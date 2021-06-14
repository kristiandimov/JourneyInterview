using Journey.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Journey.Context
{
    public class JourneyDbContext:DbContext
    {

        public JourneyDbContext() : base("JourneyDbContext")
        {
        }

        
        public DbSet<User> Users { get; set; }
        public DbSet<Travel> Travels { get; set; }
    }
}