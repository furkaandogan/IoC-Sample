using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task.Web.UI.Controllers
{
    public class CustomerController
        : BaseController
    {
        protected Core.Infrastructures.ICustomerService ICustomerService;

        public CustomerController(
            Core.Infrastructures.ICustomerService customerService,
            Core.Infrastructures.ILogger logger)
            : base(logger)
        {
            ICustomerService = customerService;
        }
        [HttpGet]
        [Route("customer")]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [Route("customer")]
        public ActionResult Post(Models.CustomerPostModel model)
        {
            Task.Models.Result<Core.Models.Customer> customer = ICustomerService.Add(AutoMapper.Mapper
                    .Map<Models.CustomerPostModel, Core.Models.Customer>(model));
            return View(customer);
        }

        [HttpPost]
        [Route("customer/{customerId}/car")]
        public ActionResult CarPost(int customerId, Models.CarPostModel model)
        {
            Core.Models.Car car = AutoMapper.Mapper
                .Map<Models.CarPostModel, Core.Models.Car>(model);

            ICustomerService.AddCar(customerId, car);
            return View();
        }

        [HttpGet]
        [Route("customer/{customerId}/cars")]
        public ActionResult Cars(int customerId)
        {
            Task.Models.Result<IList<Core.Models.Car>> cars = ICustomerService.GetCars(customerId);
            return View(cars);
        }

        [HttpPost]
        [Route("/customer/{customerId}/appointment")]
        public ActionResult Appointment(int customerId, Models.AppointmentPostModel model)
        {
            Task.Models.Result<Core.Models.Appointment> appointment = ICustomerService.CreateAppointment(customerId, model.CarId, model.Date);
            return View(appointment);
        }

    }
}