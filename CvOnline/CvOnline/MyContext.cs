using CvOnline.MyModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvOnline
{
    public class MyContext : DbContext
    {
        public MyContext() : base("CvOnlinewpf")
        {
            
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Districts> Districts { get; set; }
        public DbSet<History_Client> History_Clients { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Job_Creator> Job_Creators { get; set; }
        public DbSet<Job_Detail> Job_Details { get; set; }
        public DbSet<Provinces> Provincies { get; set; }
        public DbSet<Regencies> Regencies { get; set; }
        public DbSet<Villages> Villages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Position> Positions { get; set; }

    }

}
