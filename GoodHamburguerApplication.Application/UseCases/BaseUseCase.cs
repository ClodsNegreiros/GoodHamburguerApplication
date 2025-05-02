using MediatR;

namespace GoodHamburguerApplication.Application.UseCases
{
    public class BaseUseCase
    {
        protected readonly IMediator mediator;
        protected BaseUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
    }
}
