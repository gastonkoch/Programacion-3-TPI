using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class OrderRepository : EfRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Order?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _applicationDbContext.Orders
                                 .Include(o => o.CustomerId)
                                 .Include(o => o.SellerId)
                                 .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        }

        //public async Task<List<Order>> ProductInOrder(int id, CancellationToken cancellationToken = default)
        //{
        //    return await _applicationDbContext.Orders
        //        .Include(o => o.ProductsInOrder)
        //        .Where(o => o.Id == id)
        //        .ToListAsync(cancellationToken);
        //}

    }
}
