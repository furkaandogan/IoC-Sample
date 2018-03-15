using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Core.Models;
using Task.Models;

namespace Task.Core.Infrastructures
{
    public interface ICustomerService : IService
    {
        Task.Models.Result<Models.Customer> Add(Models.Customer customer);
        Result<IList<Car>> GetCars(int customerId);
        Result<Appointment> CreateAppointment(int customerId, int carId, DateTime date);

        Result<Car> AddCar(int customerId, Car car);
        Result<Car> DeleteCar(int customerId, int carId);
    }
}
