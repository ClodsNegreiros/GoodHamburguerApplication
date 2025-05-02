using GoodHamburguerApplication.Application.Responses.Order;
using GoodHamburguerApplication.Domain.Entities;
using GoodHamburguerApplication.Domain.Interfaces;
using MediatR;

namespace GoodHamburguerApplication.Application.Commands.Order.SendOrder
{
    public class SendOrderHandler : IRequestHandler<SendOrderCommand, OrderResponse>
    {
        private readonly IOrderRepository _repository;
        private readonly ISandwichRepository _sandwichRepository;
        private readonly IExtraRepository _extraRepository;

        public SendOrderHandler(
            IOrderRepository repository,
            ISandwichRepository sandwichRepository,
            IExtraRepository extraRepository)
        {
            _repository = repository;
            _sandwichRepository = sandwichRepository;
            _extraRepository = extraRepository;
        }

        public async Task<OrderResponse> Handle(SendOrderCommand request, CancellationToken cancellationToken)
        {
            var sandwich = await _sandwichRepository.GetByIdAsync(request.Request.SandwichId);
            if (sandwich == null)
                throw new ArgumentException("Invalid Sandwich.");

            if (request.Request.ExtraIds.Distinct().Count() != request.Request.ExtraIds.Count)
                throw new ArgumentException("Duplicate Extras aren not allowed.");

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
            var order = ToModel(sandwich, extras, total, discount);

            await _repository.SendOrderAsync(order);

            var response = ToResponse(order);

            return response;
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

        private OrderResponse ToResponse(Domain.Entities.Order model)
        {
            return new OrderResponse
            {
                CreatedAt = DateTime.Now,
                SandwichId = model.Id,
                Sandwich = model.Sandwich,
                Extras = model.Extras,
                TotalPrice = model.TotalPrice * (1 - model.Discount),
                Discount = model.Discount
            };
        }

        private Domain.Entities.Order ToModel(Sandwich sandwich, List<Extra> extras, decimal total, decimal discount)
        {
            return new Domain.Entities.Order
            {
                CreatedAt = DateTime.Now,
                SandwichId = sandwich.Id,
                Sandwich = sandwich,
                Extras = extras,
                TotalPrice = total * (1 - discount),
                Discount = discount
            };
        }

    }
}
