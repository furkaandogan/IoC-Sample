using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Core.Models
{
    public class Appointment
    {
        public Customer Customer { get; set; }
        public Car Car { get; set; }
        public DateTime Date { get; set; }
    }
}
