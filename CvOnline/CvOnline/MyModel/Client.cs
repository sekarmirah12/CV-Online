using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvOnline.MyModel
{
   public class Client : BaseModel
    {
        public string Name { get; set; }
        public string Place { get; set; }
        public DateTimeOffset Birthday { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Last_Education { get; set; }
        public string Collage { get; set; }
        public string Departement { get; set; }
        public string Password { get; set; }
        public Provinces provinces { get; set; }
        public Regencies regencies { get; set; }
        public Districts districts { get; set; }
        public Villages villages { get; set; }

    }
}
