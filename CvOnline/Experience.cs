using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvOnline.MyModel
{
    public class Experience: BaseModel
    {
        public Client client { get; set; }
        public Position Position { get; set; }
        public Company Company { get; set; }
        public int Length { get; set; }
    }
}
