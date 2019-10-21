using Microsoft.EntityFrameworkCore;
using PcnUniApp.ApplicationCore.Entities;
using PcnUniApp.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PcnUniApp.Infrastructure.Data
{
    public class SpecificationEvaluator<T> where T:BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
        {
            var query = inputQuery;

            if(specification.Criteria !=null)
            {
                query = query.Where(specification.Criteria);
            }

            query = specification.Includes.Aggregate(query,
                            (current, next) => current.Include(next));

            query = specification.IncludeStrings.Aggregate(query,
                              (current, next) => current.Include(next));

            if(specification.OrderBy !=null)
            {
                query = query.OrderBy(specification.OrderBy);
            }

            if(specification.OrderByDescending != null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }

            if(specification.GroupBy !=null)
            {
                query = query.GroupBy(specification.GroupBy).SelectMany(x => x);
            }

            if(specification.IsPagingEnabled)
            {
                query = query.Skip(specification.Skip)
                    .Take(specification.Take);
            }


            return query;
        }
    }
}
