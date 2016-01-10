#region Using Directives

using System;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using MusicStore.Infrastructure.UnitOfWork;
using MusicStore.Model.Customers;
using MusicStore.Model.Ecommerce;
using MusicStore.Model.Orders;
using MusicStore.Model.Shared;
using MusicStore.Services.Interfaces;
using MusicStore.Services.Mapping;
using MusicStore.Services.Messaging.OrderService;

#endregion

namespace MusicStore.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly INextSequenceRepository _nextSequenceRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _uow;

        public OrderService(ICartRepository cartRepository, ICustomerRepository customerRepository,
            INextSequenceRepository nextSequenceRepository, IOrderRepository orderRepository, IUnitOfWork uow)
        {
            _cartRepository = cartRepository;
            _customerRepository = customerRepository;
            _nextSequenceRepository = nextSequenceRepository;
            _orderRepository = orderRepository;
            _uow = uow;
        }

        public CreateOrderResponse CreateOrder(CreateOrderRequest request)
        {
            var response = new CreateOrderResponse();

            var customer = _customerRepository.FindBy(request.CustomerId);

            var deliveryAddress = new DeliveryAddress
            {
                Customer = customer,
                Name = string.Format("{0} {1}", customer.FirstName, customer.LastName),
                AddressLine1 = request.AddressLine1,
                AddressLine2 = request.AddressLine2,
                City = request.City,
                State = request.State,
                ZipCode = request.ZipCode
            };

            customer.AddAddress(deliveryAddress);

            _customerRepository.Save(customer);

            var cart = _cartRepository.FindBy(request.CartId);

            var order = cart.ConvertToOrder();

            order.Customer = customer;

            order.OrderNumber = _nextSequenceRepository.ExecuteStoredProcedure("GetNextInSequence",
                new[] { new SqlParameter("sequenceKey", "SalesOrder") }).NextSequenceFormatted;

            order.DeliveryAddress = deliveryAddress;

            ThrowExceptionIfOrderIsInvalid(order);

            _orderRepository.Save(order);

            _cartRepository.Remove(cart);

            _uow.Commit();

            response.Order = order.ConvertToOrderView();

            return response;
        }

        public GetOrderResponse GetOrder(GetOrderRequest request)
        {
            var response = new GetOrderResponse();

            var order = _orderRepository.FindBy(request.Id);

            response.Order = order.ConvertToOrderView();

            return response;
        }

        private static void ThrowExceptionIfOrderIsInvalid(Order order)
        {
            if (!order.GetBrokenRules().Any()) { return; }

            var brokenRules = new StringBuilder();

            brokenRules.AppendLine("There were problems saving the order:");

            foreach (var businessRule in order.GetBrokenRules())
            {
                brokenRules.AppendLine(businessRule.Rule);
            }

            throw new ApplicationException(brokenRules.ToString());
        }
    }
}