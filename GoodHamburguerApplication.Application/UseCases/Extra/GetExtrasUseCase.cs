using GoodHamburguerApplication.Application.Interfaces.Order;
using GoodHamburguerApplication.Application.Queries.Sandwich.GetSandwiches;
using MediatR;

namespace GoodHamburguerApplication.Application.UseCases.Order
{
    public class GetExtrasUseCase : BaseUseCase, IGetExtrasUseCase
    {
        public GetExtrasUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<List<Domain.Entities.Extra>> Execute()
        {
            return await mediator.Send(new GetExtrasQuery());
        }
    }
}
