using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentCar.Models.Response;

namespace RentCar.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<PaginationBaseResponse<T>> ToPagedResultAsync<T>(
            this IQueryable<T> query,
            int pageNumber,
            int pageSize) where T: class
        {
            if (pageNumber <= 0 || pageSize <= 0)
                throw new ArgumentException("PageNumber and PageSize must be greater than zero.");

            var totalItems = await query.CountAsync();
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginationBaseResponse<T>
            {
                Items = items,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalItems
            };
        }
    }
}