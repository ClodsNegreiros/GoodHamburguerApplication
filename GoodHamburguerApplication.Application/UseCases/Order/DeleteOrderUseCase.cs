using GoodHamburguerApplication.Application.Commands.Order.SendOrder;
using GoodHamburguerApplication.Application.Interfaces.Order;
using MediatR;

namespace GoodHamburguerApplication.Application.UseCases.Order
{
    public class DeleteOrderUseCase : BaseUseCase, IDeleteOrderUseCase
    {
        public DeleteOrderUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> Execute(int id)
        {
            return await mediator.Send(new DeleteOrderCommand(id));
        }
    }
}
