using GoodHamburguerApplication.Application.Requests;
using GoodHamburguerApplication.Application.Responses.Order;
using MediatR;

namespace GoodHamburguerApplication.Application.Commands.Order.SendOrder
{
    public class UpdateOrderCommand : IRequest<bool>
    {
        public int OrderId { get; set; }
        public UpdateOrderRequest Request { get; set; }

        public UpdateOrderCommand(int orderId, UpdateOrderRequest request)
        {
            Request = request;
            OrderId = orderId;
        }
    }
}
