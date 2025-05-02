using GoodHamburguerApplication.Domain.Interfaces;
using MediatR;

namespace GoodHamburguerApplication.Application.Commands.Order.SendOrder
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, bool>
    {
        private readonly IOrderRepository _repository;

        public DeleteOrderHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
        {
            var existingOrder = _repository.GetOrderByIdAsync(command.Id);
            if (existingOrder == null)
            {
                throw new KeyNotFoundException($"Sala com Id {command.Id} não encontrado.");
            }

            await _repository.DeleteOrderAsync(existingOrder.Result);

            return true;
        }
    }
}
