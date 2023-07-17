using MediatR;
using Order.Application.Repository;
using Order.Domain.AggregateModels.BuyerModels;
using Order.Domain.Events;

namespace Order.Application.DomainEventHandlers
{
    public class OrderStartedDomainEventHandler : INotificationHandler<OrderStartedDomainEvent>
    {
        private readonly IBuyerRepository buyerRepository;

        public OrderStartedDomainEventHandler(IBuyerRepository buyerRepository)
        {
            this.buyerRepository = buyerRepository ?? throw new ArgumentNullException(nameof(buyerRepository));
        }

        //bize bu notifcation geldiğinde gerekli işlemleri yapacağız
        //order start olduğunda buyer bilmiyor ise burda onu kontrol edip kullanıcaz
        public Task Handle(OrderStartedDomainEvent notification, CancellationToken cancellationToken)
        {
            //buyur o an create edilmediyse yeni bir buyer create edeceğiz
            if (notification.Order.UserName == "")
            {
                var buyer = new Buyer(notification.Order.UserName);
                // buyerRepository.Add(buyer); // yeni bir buyer yaratıp orde'a set edebiliriz

                // set order's buyerId
            }

            return Task.CompletedTask;
        }
    }
}
