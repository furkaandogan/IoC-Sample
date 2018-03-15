using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Models.Tables
{
    public class Customer : Base
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Customer()
            : base()
        {

        }
        public Customer(string name, string surname, string email, string phone)
            : this(0, name, surname, email, phone)
        {
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.Phone = phone;
        }
        public Customer(int id, string name, string surname, string email, string phone)
            : base(id)
        {
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.Phone = phone;
        }
    }
}
