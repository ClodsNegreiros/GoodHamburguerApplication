using GoodHamburguerApplication.Application.Interfaces.Order;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburgerApplication.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ExtraController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get([FromServices] IGetExtrasUseCase useCase)
        {
            var result = await useCase.Execute();
            return Ok(result);
        }
    }
}
