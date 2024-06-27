using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderProduct
    {
        public int OrdersWithProductsId { get; set; }
        public int ProductsInOrderId { get; set; }
    }
}
