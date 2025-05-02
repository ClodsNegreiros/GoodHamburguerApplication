using GoodHamburguerApplication.Domain.Interfaces;
using MediatR;

namespace GoodHamburguerApplication.Application.Queries.Order.GetOrders
{
    internal class GetOrdersHandler : IRequestHandler<GetOrdersQuery, List<Domain.Entities.Order>>
    {
        private readonly IOrderRepository _repository;
        
        public GetOrdersHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Domain.Entities.Order>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetOrdersAsync();
        }
    }
}
