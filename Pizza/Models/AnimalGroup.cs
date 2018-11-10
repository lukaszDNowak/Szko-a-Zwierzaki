using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pizza.Models
{
    public class AnimalGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Animal> Animals { get; set; }
    }
}