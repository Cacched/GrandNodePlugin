using EAppointment.Entites;
using EAppointment.Services;
using Grand.Core;
using Grand.Domain.Catalog;
using Grand.Plugin.Misc.AppointmentBooking.Commands.Models;
using Grand.Plugin.Misc.AppointmentBooking.DTOs;
using Grand.Plugin.Misc.AppointmentBooking.Models;
using Grand.Plugin.Misc.AppointmentManager;
using Grand.Services.Catalog;
using Grand.Services.Customers;
using Grand.Services.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Grand.Domain.Customers;

namespace Grand.Plugin.Misc.AppointmentManager.ViewModelServices
{
    public class AppointmentsDtoService : IAppointmentsDtoService
    {
        private readonly IMediator _mediator;
        private readonly IProductService _productService;
        private readonly IAppointmentServices _bookAppointmentService;
        private readonly ICustomerService _customerService;
        private readonly IWorkContext _workContext;
        private readonly ICustomerActivityService _customerActivityService;
        private readonly ICategoryService _productCategoryService;

        public AppointmentsDtoService(IAppointmentServices bookAppointmentService,
            ICustomerService customerService,
            IWorkContext workContext,
            ICustomerActivityService customerActivityService,
            IProductService productService,
            IMediator mediator,
            ICategoryService productCategoryService
            )
        {
            _bookAppointmentService = bookAppointmentService;
            _customerService = customerService;
            _workContext = workContext;
            _customerActivityService = customerActivityService;
            _productService = productService;
            _mediator = mediator;
            _productCategoryService = productCategoryService;

        }

        public  BookAppointmentDto PrepareBookAppointmentModel(Customer customer )
        {
            var category = _productCategoryService.GetAllCategories(categoryName: "Vaccine ").Result.FirstOrDefault();
            List<string> categoryIds = new List<string>();
            categoryIds.Add(category.Id);
            var model = new BookAppointmentDto();
            model.CustomerId = customer.Id;
            model.CustomerName = customer.GetFullName();
            IEnumerable<Product> vaccines ;
            vaccines = _productService.SearchProducts(categoryIds:categoryIds).Result.products;
            var vaccineList = new List<SelectListItem>();
            vaccineList.Add(new SelectListItem {
                Selected = true,
                Value = "-1",
                Text = "Select a Vaccine"
            });
            foreach (var vaccine in vaccines)
            {
                vaccineList.Add(new SelectListItem {
                    Value = vaccine.Id,
                    Text = vaccine.Name
                });
            }
            model.VaccinesList = vaccineList;
            return   model;
        }
        public  async Task DeleteSelected(ListAppointmentsDto models)
        {
            models = await _mediator.Send(new DeleteAppointmentCommand() { Model = models });
        }

        public async Task EditAppointment(ListAppointmentsDto model)
        {
            model = await _mediator.Send(new UpdateAppointmentCommand() { Model = model });
        }
        public async Task InsertAppointment(BookAppointmentDto model)
        {
            model = await _mediator.Send(new AddAppointmentCommand() { Model = model });
        }

    }

}
