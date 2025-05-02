using GoodHamburguerApplication.Application.Responses.Order;
using GoodHamburguerApplication.Domain.Entities;
using GoodHamburguerApplication.Domain.Interfaces;
using MediatR;

namespace GoodHamburguerApplication.Application.Commands.Order.SendOrder
{
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, bool>
    {
        private readonly IOrderRepository _repository;
        private readonly ISandwichRepository _sandwichRepository;
        private readonly IExtraRepository _extraRepository;

        public UpdateOrderHandler(
            IOrderRepository repository,
            ISandwichRepository sandwichRepository,
            IExtraRepository extraRepository)
        {
            _repository = repository;
            _sandwichRepository = sandwichRepository;
            _extraRepository = extraRepository;
        }

        public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var existingOrder = await _repository.GetOrderByIdAsync(request.OrderId, asNoTracking: true);
            if (existingOrder == null)
                throw new ArgumentException("Order not found.");

            _repository.Attach(existingOrder);

            var sandwich = await _sandwichRepository.GetByIdAsync(request.Request.SandwichId);
            if (sandwich == null)
                throw new ArgumentException("Invalid Sandwich.");

            if (request.Request.ExtraIds.Distinct().Count() != request.Request.ExtraIds.Count)
                throw new ArgumentException("Duplicate Extras are not allowed.");

            var extras = new List<Extra>();
            foreach (var extraId in request.Request.ExtraIds)
            {
                var extra = await _extraRepository.GetByIdAsync(extraId);
                if (extra == null)
                    throw new ArgumentException($"Extra with Id {extraId} not found.");
                extras.Add(extra);
            }

            decimal total = CalculateTotal(sandwich, extras);
            decimal discount = CalculateDiscount(extras);

            existingOrder.SandwichId = sandwich.Id;
            existingOrder.Sandwich = sandwich;

            existingOrder.Extras = new List<Extra>(extras);

            existingOrder.TotalPrice = total * (1 - discount);
            existingOrder.Discount = discount;

            await _repository.UpdateOrderAsync(existingOrder);

            return true;
        }

        private decimal CalculateTotal(Sandwich sandwich, List<Extra> extras)
        {
            return sandwich.Price + extras.Sum(e => e.Price);
        }

        private decimal CalculateDiscount(List<Extra> extras)
        {
            var extraNames = extras.Select(e => e.Name.ToLower()).ToList();
            bool hasFries = extraNames.Contains("fries");
            bool hasSoda = extraNames.Contains("soft drink");

            if (hasFries && hasSoda)
                return 0.20m;
            else if (hasSoda)
                return 0.15m;
            else if (hasFries)
                return 0.10m;

            return 0m;
        }

    }
}
