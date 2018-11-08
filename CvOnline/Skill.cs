using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvOnline.MyModel
{
    public class Skill: BaseModel
    {
        public string Name { get; set; }
        public Client client { get; set; }
    }
}
