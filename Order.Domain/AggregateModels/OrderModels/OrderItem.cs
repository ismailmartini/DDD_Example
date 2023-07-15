using Order.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.AggregateModels.OrderModels
{
    public class OrderItem : BaseEntity
    {

        public int Quantity { get; private set; }

        public decimal Price { get; private set; }

        public int ProductId { get; private set; }

        public OrderItem(int quantity, decimal price, int productId)
        {
            Quantity = quantity;
            Price = price;
            ProductId = productId;

            //validation rules will be here

            if (quantity <1)
                throw new Exception("quantity must be greater zero");

            if (price <1)
                throw new Exception("quantity must be greater zero");

            if (productId < 1)
                throw new Exception("productId cannot be empty");

        }
    }
}
