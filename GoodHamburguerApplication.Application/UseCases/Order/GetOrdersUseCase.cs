using GoodHamburguerApplication.Application.Interfaces.Order;
using GoodHamburguerApplication.Application.Queries.Order.GetOrders;
using MediatR;

namespace GoodHamburguerApplication.Application.UseCases.Order
{
    public class GetOrdersUseCase : BaseUseCase, IGetOrdersUseCase
    {
        public GetOrdersUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<List<Domain.Entities.Order>> Execute()
        {
            return await mediator.Send(new GetOrdersQuery());
        }
    }
}
