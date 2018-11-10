using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Pizza.Models
{
    public class DB : DbContext
    {
        public DB() : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Amimals;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        { }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalGroup> AnimalGroups { get; set; }
    }
}