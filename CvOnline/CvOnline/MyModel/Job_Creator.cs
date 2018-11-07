using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvOnline.MyModel
{
   public class Job_Creator : BaseModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Company companies { get; set; }
    }
}
