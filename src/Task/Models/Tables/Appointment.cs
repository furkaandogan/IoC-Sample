using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Models.Tables
{
    public class Appointment : Base
    {
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public DateTime Date { get; set; }
    }
}
