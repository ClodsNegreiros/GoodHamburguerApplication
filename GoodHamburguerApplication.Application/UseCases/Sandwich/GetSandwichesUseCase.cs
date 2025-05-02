using GoodHamburguerApplication.Application.Interfaces.Order;
using GoodHamburguerApplication.Application.Queries.Sandwich.GetSandwiches;
using MediatR;

namespace GoodHamburguerApplication.Application.UseCases.Order
{
    public class GetSandwichesUseCase : BaseUseCase, IGetSandwichesUseCase
    {
        public GetSandwichesUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<List<Domain.Entities.Sandwich>> Execute()
        {
            return await mediator.Send(new GetSandwichesQuery());
        }
    }
}
