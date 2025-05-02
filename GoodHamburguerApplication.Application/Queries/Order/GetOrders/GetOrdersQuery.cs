using MediatR;

namespace GoodHamburguerApplication.Application.Queries.Order.GetOrders
{
    public class GetOrdersQuery : IRequest<List<Domain.Entities.Order>>
    {
    }
}
