using GoodHamburguerApplication.Application.Commands.Order.SendOrder;
using GoodHamburguerApplication.Application.Interfaces.Order;
using GoodHamburguerApplication.Application.Requests;
using GoodHamburguerApplication.Application.Responses.Order;
using MediatR;

namespace GoodHamburguerApplication.Application.UseCases.Order
{
    public class SendOrderUseCase : BaseUseCase, ISendOrderUseCase
    {
        public SendOrderUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<OrderResponse> Execute(SendOrderRequest request)
        {
            return await mediator.Send(new SendOrderCommand(request));
        }
    }
}
