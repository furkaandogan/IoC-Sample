using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Core.Models;
using Task.Models;
using Task.Repository.Infrastructures;

namespace Task.Core
{
    public class CustomerService
        : Infrastructures.ICustomerService
    {
        private ICustomerRepository ICustomerRepository;
        private IAppointmentRepository IAppointmentRepository;
        private ICarRepository ICarRepository;
        private Validators.ICustomerValidator ICustomerValidator;

        public CustomerService(
            ICustomerRepository customerRepository,
            ICarRepository carRepository,
            IAppointmentRepository appointmentRepository,
            Validators.ICustomerValidator customerValidator)
        {
            this.ICustomerRepository = customerRepository;
            this.ICarRepository = carRepository;
            this.IAppointmentRepository = appointmentRepository;
            this.ICustomerValidator = customerValidator;
        }

        public Result<Customer> Add(Customer customer)
        {
            Result<Customer> result = new Result<Customer>();
            try
            {
                Validators.ValidateResult validateResult = ICustomerValidator.Valid(customer);
                if (validateResult.IsOk)
                {
                    Task.Models.Tables.Customer customerDTO = Mapper
                        .Map<Customer, Task.Models.Tables.Customer>(customer);
                    ICustomerRepository.Add(customerDTO);
                    result.SetSucces("müşteri eklendi.", customer);
                }
                else
                {
                    result.Errors = validateResult.Errors;
                }
            }
            catch (Exception ex)
            {

                result.SetError(ex);
            }
            return result;
        }

        public Result<IList<Car>> GetCars(int customerId)
        {
            Result<IList<Car>> result = new Result<IList<Car>>();
            try
            {
                Customer customer = Mapper.Map<Task.Models.Tables.Customer, Customer>(ICustomerRepository.GetById(customerId));
                IList<Car> cars = ICarRepository.GetByCustomerId(customerId)
                    .ToList()
                    .Select(x =>
                    {
                        Car car = Mapper.Map<Task.Models.Tables.Car, Car>(x);
                        car.Customer = customer;
                        return car;
                    })
                    .ToList();
                result.SetSucces(data: cars);
            }
            catch (Exception ex)
            {
                result.SetError(ex);
            }
            return result;
        }

        public Result<Appointment> CreateAppointment(int customerId, int carId, DateTime date)
        {
            Result<Appointment> result = new Result<Appointment>();
            try
            {
                Customer customer = Mapper.Map<Task.Models.Tables.Customer, Customer>(ICustomerRepository.GetById(customerId));
                Car car = Mapper.Map<Task.Models.Tables.Car, Car>(ICarRepository.GetById(carId));
                if (customer != null && car != null)
                {
                    IAppointmentRepository.Add(new Task.Models.Tables.Appointment()
                    {
                        CarId = car.Id,
                        CustomerId = customer.Id,
                        Date = date
                    });
                    result.SetSucces(data: new Appointment()
                    {
                        Car = car,
                        Customer = customer,
                        Date = date
                    });
                }

            }
            catch (Exception ex)
            {
                result.SetError(ex);
            }
            return result;
        }

        public Result<Car> AddCar(int customerId, Car car)
        {

            Result<Car> result = new Result<Car>();
            try
            {
                if (ICarRepository.IsExistsByPlate(customerId, car.Plate))
                {
                    Customer customer = Mapper.Map<Task.Models.Tables.Customer, Customer>(ICustomerRepository.GetById(customerId));
                    if (customer != null && car != null)
                    {
                        ICarRepository.Add(new Task.Models.Tables.Car()
                        {
                            Brand = car.Brand,
                            CustomerId = customer.Id,
                            Model = car.Model,
                            Plate = car.Plate,
                            Year = car.Year
                        });
                    }
                    else
                    {
                        result.SetError("müşteri bilgisi buluanmadı");
                    }
                }
                else
                {
                    result.SetError("bu plakadaki araç zaten ekli", car);
                }

            }
            catch (Exception ex)
            {
                result.SetError(ex);
            }
            return result;
        }

        public Result<Car> DeleteCar(int customerId, int carId)
        {
            Result<Car> result = new Result<Car>();
            try
            {
                if (ICarRepository.IsExistsByCarId(customerId, carId))
                {
                    ICarRepository.Delete(new Task.Models.Tables.Car()
                    {
                        Id = carId
                    });
                    result.SetSucces();
                }
                else
                {
                    result.SetError("silmek istediğiniz aracın sahini değilsiniz");
                }

            }
            catch (Exception ex)
            {
                result.SetError(ex);
            }
            return result;
        }
    }
}
