using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvOnline.MyModel
{
    public class Language: BaseModel
    {
        public Client client { get; set; }
        public string Name { get; set; }
    }
}
