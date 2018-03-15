using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Core.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", this.Name, this.Surname);
            }
        }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
