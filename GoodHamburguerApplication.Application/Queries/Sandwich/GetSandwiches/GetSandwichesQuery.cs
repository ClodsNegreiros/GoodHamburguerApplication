using MediatR;

namespace GoodHamburguerApplication.Application.Queries.Sandwich.GetSandwiches
{
    public class GetSandwichesQuery : IRequest<List<Domain.Entities.Sandwich>>
    {
    }
}
