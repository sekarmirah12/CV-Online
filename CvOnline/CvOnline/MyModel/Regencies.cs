using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvOnline.MyModel
{
    public class Regencies : BaseModel
    {
        public string Name { get; set; }
        public Provinces provinces { get; set; }
    }
}
