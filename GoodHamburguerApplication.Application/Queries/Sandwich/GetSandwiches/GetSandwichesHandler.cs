using GoodHamburguerApplication.Application.Queries.Sandwich.GetSandwiches;
using GoodHamburguerApplication.Domain.Interfaces;
using MediatR;

namespace GoodHamburguerApplication.Application.Queries.Order.GetOrders
{
    internal class GetSandwichesHandler : IRequestHandler<GetSandwichesQuery, List<Domain.Entities.Sandwich>>
    {
        private readonly ISandwichRepository _repository;
        
        public GetSandwichesHandler(ISandwichRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Domain.Entities.Sandwich>> Handle(GetSandwichesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetSandiwchesAsync();
        }
    }
}
