using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Models.Tables
{
    public abstract class Base
    {
        [Key]
        public int Id { get; set; }

        public Base()
        {

        }
        public Base(int id)
        {
            this.Id = id;
        }

    }
}
