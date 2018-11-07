using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvOnline.MyModel
{
    public class Job_Detail : BaseModel
    {
        public string Category { get; set; }
        public string Position { get; set; }
        public string Type { get; set; }
        public string Last_Education { get; set; }
        public int Max_Age { get; set; }
        public string Work_Experience { get; set; }
        public int Salary { get; set; }
        public string Company { get; set; }
        public Job_Creator job_creators { get; set; }
        public Villages Villages { get; set; }
    }
}
