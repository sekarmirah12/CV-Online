using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvOnline.MyModel
{
   public  class Company :BaseModel
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public Provinces provinces { get; set; }
        public Regencies regencies { get; set; }
        public Districts districts { get; set; }
        public Villages villages { get; set; }
    }
}
