using MediatR;

namespace Order.Domain.Events
{
    public class OrderStartedDomainEvent : INotification
    {
       
        public string UserName { get; set; }

        public AggregateModels.OrderModels.Order Order { get; set; }

        public OrderStartedDomainEvent(string userName, AggregateModels.OrderModels.Order order)
        {
            UserName = userName;
            Order = order ?? throw new ArgumentNullException(nameof(order));

            
        }


        /*
         * order startted event handle application'da yapılacak
         * 
         * 
         */
    }



}
