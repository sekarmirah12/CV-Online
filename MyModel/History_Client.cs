using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvOnline.MyModel
{
   public class History_Client : BaseModel
    {
       public Client client { get; set; }
       public Job_List job_list { get; set; }
    }
}
