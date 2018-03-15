using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Repository
{
    public class TaskContext : DbContext
    {
        public TaskContext()
            : this("MainDb")
        {

        }
        public TaskContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public DbSet<Models.Tables.Customer> Customer { get; set; }
        public DbSet<Models.Tables.Car> Car { get; set; }
        public DbSet<Models.Tables.Appointment> Appointment { get; set; }

    }
}
