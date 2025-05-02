using GoodHamburguerApplication.Application.Commands.Order.SendOrder;
using GoodHamburguerApplication.Application.Interfaces.Order;
using GoodHamburguerApplication.Application.Requests;
using MediatR;

namespace GoodHamburguerApplication.Application.UseCases.Order
{
    public class UpdateOrderUseCase : BaseUseCase, IUpdateOrderUseCase
    {
        public UpdateOrderUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> Execute(int id, UpdateOrderRequest request)
        {
            return await mediator.Send(new UpdateOrderCommand(id, request));
        }
    }
}
