using FNS.CRUDService.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FNS.CRUDService.Extensions
{
    public static class IQueryableExtensions
    {
        public static async Task<PagingResult> Paginate<T>(this IQueryable<T> queryable, PagingQuery queryRequest, Expression<Func<T, bool>> predicate = null)
        {
            var start = queryRequest.PageIndex * queryRequest.PageSize;
            var length = queryRequest.PageSize;

            int pageSize = length > 0 ? Convert.ToInt32(length) : 10;
            int skip = start > 0 ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            if (queryRequest.Order != null && !string.IsNullOrEmpty(queryRequest.Order.Order))
            {
                queryable = queryable.OrderBy(string.Format("{0} {1}", queryRequest.Order.Order, queryRequest.Order.Direction));
            }

            if (predicate != null && queryRequest.Search != null && !string.IsNullOrEmpty(queryRequest.Search.Value))
            {
                queryable = queryable.Where(predicate);
            }

            recordsTotal = await queryable.CountAsync();

            var result = await queryable.Skip(skip).Take(pageSize).ToDynamicListAsync();

            return new PagingResult
            {
                RecordsFiltered = result.Count(),
                RecordsTotal = recordsTotal,
                PageIndex = queryRequest.PageIndex,
                Data = result
            };
        }
    }
}
