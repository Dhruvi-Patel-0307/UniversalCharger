using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UniversalCharger.Models
{
    public class Charger
    {
        public int ID { get; set; }

        public string Name{ get; set; }

       
        public string Company { get; set; }

        public string Colour { get; set; }
        public decimal Price { get; set; }

        public string type { get; set; }
        public decimal voltage { get; set; }

        public int Rating { get; set; }
    }
}
