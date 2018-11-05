using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvOnline.MyModel
{
   public class Job_Detail : BaseModel
    {
        public string Last_Education { get; set; }
        public int Max_Age { get; set; }
        public string Work_Experience { get; set; }
        public string Type { get; set; }
        public int Salary { get; set; }
        public Job_Creator job_creator { get; set; }
        public Job_List job_list { get; set; }
        public Province province { get; set; }
        public Regencies regencies { get; set; }
        public Districts districts { get; set; }
        public Villages villages { get; set; }
    }
}
