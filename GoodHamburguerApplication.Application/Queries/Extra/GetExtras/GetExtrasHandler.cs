using GoodHamburguerApplication.Application.Queries.Sandwich.GetSandwiches;
using GoodHamburguerApplication.Domain.Interfaces;
using MediatR;

namespace GoodHamburguerApplication.Application.Queries.Order.GetOrders
{
    internal class GetExtrasHandler : IRequestHandler<GetExtrasQuery, List<Domain.Entities.Extra>>
    {
        private readonly IExtraRepository _repository;
        
        public GetExtrasHandler(IExtraRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Domain.Entities.Extra>> Handle(GetExtrasQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetExtrasAsync();
        }
    }
}
