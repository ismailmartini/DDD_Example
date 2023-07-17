using Order.Domain.Events;
using Order.Domain.SeedWork;

namespace Order.Domain.AggregateModels.OrderModels
{
    //Bütün order modellerini yöneticeğimiz modelimiz 
    public class Order : BaseEntity, IAggregateRoot
    {
        //aggreagateroot larda property'lerimizin kontrol bizde olmalı dışardan müdahale edilmemeli validation kurallarını işletilmiş olmalı
        public DateTime OrderDate { get; private set; }

        public string Description { get; private set; }


        public string UserName { get; private set; }

        public string OrderStatus { get; private set; }

        public Address Address { get; private set; }

        public ICollection<OrderItem> OrderItems { get; private set; }


        public Order(DateTime orderDate, string description, string userName, string orderStatus, Address address, ICollection<OrderItem> orderItems)
        {
            if (orderDate < DateTime.Now)
                throw new Exception("Orderdate must be greater than now");

            if (address.City == "")
                throw new Exception("city cannot be empty");

            OrderDate = orderDate;
            Description = description ?? throw new ArgumentNullException(nameof(description));
            UserName = userName;
            OrderStatus = orderStatus ?? throw new ArgumentNullException(nameof(orderStatus));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            OrderItems = orderItems ?? throw new ArgumentNullException(nameof(orderItems));

            //baseentity'den buyer username boş ise event fırlat ve mediatr ile yakalayıp yeni bir buyer oluştur
            AddDomainEvents(new OrderStartedDomainEvent(userName, this));
        }

        public void AddOrderItem(int quantity, decimal price, int productId)
        {
            OrderItem item = new(quantity, price, productId);

            OrderItems.Add(item);
        }
    }
}
