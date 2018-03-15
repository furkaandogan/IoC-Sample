using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Core
{
    public class OutputLogger
        : Infrastructures.ILogger
    {
        public void Write(Exception ex)
        {
            Write(ex.Message);
        }

        public void Write(string message)
        {
            Debug.Print(message);
        }
    }
}
