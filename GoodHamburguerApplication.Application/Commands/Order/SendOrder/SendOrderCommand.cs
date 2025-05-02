using GoodHamburguerApplication.Application.Requests;
using GoodHamburguerApplication.Application.Responses.Order;
using MediatR;

namespace GoodHamburguerApplication.Application.Commands.Order.SendOrder
{
    public class SendOrderCommand : IRequest<OrderResponse>
    {
        public SendOrderRequest Request { get; set; }

        public SendOrderCommand(SendOrderRequest request)
        {
            Request = request;
        }
    }
}
