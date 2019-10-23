using PcnUniApp.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcnUniApp.Web.Interfaces
{
    public interface IDepartmentViewModelService
    {
        Task<DepartmentIndexViewModel> GetDeprtments(int pageIndex, int itemsPage, string searchFilter);

        Task CreateDepartmentAsync(DeprtmentViewModel department);

        Task UpdateDepartmentAsync(DeprtmentViewModel department);


        Task<DeprtmentViewModel> GetDepartmentById(int id);
    }
}
