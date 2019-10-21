using PcnUniApp.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PcnUniApp.ApplicationCore.Specifications
{
   public  class DepartmentFilterPaginatedSpecification  : BaseSpecification<Department>
    {
        public DepartmentFilterPaginatedSpecification(int skip, int take, string criteria) :
                        base(s => (string.IsNullOrWhiteSpace(criteria) || s.Name.Contains(criteria)))
        {
            ApplyPaging(skip, take);
        }
    }
}
