using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jk_Roshni.Models.Entities;
namespace Jk_Roshni.Models.JkDb
{
    public class JkDbContext:DbContext
    {
       
       public JkDbContext(DbContextOptions<JkDbContext> options):base(options)
        {

        }

        public DbSet<Technician> technicians { get; set; }
        public DbSet<Ragistration_Complain> ragistration_Complains { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Registration> registrations { get; set; }
        public DbSet<Otp> otps { get; set; }
        public DbSet<Login> logins { get; set; }

        public DbSet<AdminLogin> adminLogins { get; set; }
    }
}
