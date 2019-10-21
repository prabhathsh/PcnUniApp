using Microsoft.Extensions.Logging;
using PcnUniApp.ApplicationCore.Entities;
using PcnUniApp.ApplicationCore.Interfaces;
using PcnUniApp.ApplicationCore.Specifications;
using PcnUniApp.Web.Interfaces;
using PcnUniApp.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcnUniApp.Web.Services
{
    public class DepartmentViewModelService : IDepartmentViewModelService
    {

        private readonly ILogger<DepartmentViewModelService> _logger;
        private readonly IAsyncRepository<Department> _departmentRepository;      
        private readonly IUriComposer _uriComposer;

        public DepartmentViewModelService(ILoggerFactory loggerFactory,
                                        IAsyncRepository<Department> departmentRepository,
                                        IUriComposer uriComposer
                                        )
        {
            _logger = loggerFactory.CreateLogger<DepartmentViewModelService>();
            _departmentRepository = departmentRepository;
            _uriComposer = uriComposer;
        }
        public async  Task<DepartmentIndexViewModel> GetDeprtments(int pageIndex, int itemsPage, string searchFilter)
        {
            _logger.LogInformation("GetDeprtments called.");

            var filterSpecification = new DepartmentFilterSpecification(searchFilter);
            _logger.LogInformation("After calling  DepartmentFilterSpecification.");

            //var filterPaginatedSpecification =
            //   new DepartmentFilterPaginatedSpecification(itemsPage * pageIndex, itemsPage, searchFilter);
            var deprtments = await _departmentRepository.ListAsync(filterSpecification);
            var vm = new DepartmentIndexViewModel()
            {
                Departments = deprtments.Select(d => new DeprtmentViewModel()
                {
                    DeprtmentId = d.Id,
                    Budget = d.Budget,
                    DeprtmentName = d.Name,
                    StartDate = d.StartDate
                })
            };

            return vm;
        }
    }
}
