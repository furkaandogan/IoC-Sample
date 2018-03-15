using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Repository.Infrastructures
{
    public interface ICarRepository
        : IRepository<Models.Tables.Car>
    {
        IQueryable<Models.Tables.Car> GetByCustomerId(int customerId);

        bool IsExistsByPlate(int customerId, string plate);
        bool IsExistsByCarId(int customerId, int carId);
    }
}
