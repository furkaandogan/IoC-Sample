using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Models.Tables;
using Task.Repository.Infrastructures;

namespace Task.Repository.SQLServer
{
    public class CarRepository :
        BaseRepository<Models.Tables.Car, TaskContext>, ICarRepository
    {
        public IQueryable<Car> GetByCustomerId(int customerId)
        {
            return DbSet.Where(x => x.CustomerId == customerId);
        }

        public bool IsExistsByCarId(int customerId, int carId)
        {
            return DbSet.Any(x => x.Id== carId && x.CustomerId == customerId);
        }

        public bool IsExistsByPlate(int customerId, string plate)
        {
            return DbSet.Any(x => x.Plate == plate && x.CustomerId == customerId);
        }
    }
}
