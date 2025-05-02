using GoodHamburguerApplication.Application.Interfaces.Order;
using GoodHamburguerApplication.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburgerApplication.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] SendOrderRequest request,
            [FromServices] ISendOrderUseCase useCase)
        {
            var result = await useCase.Execute(request);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromServices] IGetOrdersUseCase useCase)
        {
            var result = await useCase.Execute();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(
            [FromRoute] int id,
            [FromServices] IDeleteOrderUseCase useCase)
        {
            var result = await useCase.Execute(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            [FromBody] UpdateOrderRequest request,
            [FromServices] IUpdateOrderUseCase useCase)
        {
            var result = await useCase.Execute(id, request);
            return Ok(result);
        }
    }
}
