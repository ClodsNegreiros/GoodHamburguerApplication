using GoodHamburguerApplication.Application.Interfaces.Order;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburgerApplication.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromServices] IGetSandwichesUseCase sandwichUseCase,
            [FromServices] IGetExtrasUseCase extraUseCase)
        {
            var sandwichResult = await sandwichUseCase.Execute();
            var extraResult = await extraUseCase.Execute();
            
            return Ok(new
            {
                Sandwiches = sandwichResult,
                Extras = extraResult
            });
        }
    }
}
