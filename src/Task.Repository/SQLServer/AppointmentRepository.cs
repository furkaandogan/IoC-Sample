using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Repository.Infrastructures;

namespace Task.Repository.SQLServer
{
    public class AppointmentRepository :
     BaseRepository<Models.Tables.Appointment, TaskContext>, IAppointmentRepository
    {

    }
}
