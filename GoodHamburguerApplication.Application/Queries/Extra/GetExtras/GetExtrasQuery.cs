using MediatR;

namespace GoodHamburguerApplication.Application.Queries.Sandwich.GetSandwiches
{
    public class GetExtrasQuery : IRequest<List<Domain.Entities.Extra>>
    {
    }
}
