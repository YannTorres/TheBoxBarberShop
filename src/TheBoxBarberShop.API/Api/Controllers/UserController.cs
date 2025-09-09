using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheBoxBarberShop.Application.UseCases.Users.Register;
using TheBoxBarberShop.Communication.Request.Users;
using TheBoxBarberShop.Communication.Response.Users;
using TheBoxBarberShop.Exceptions;

namespace TheBoxBarberShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterUserJson), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterUser(
            [FromBody] RequestRegisteredUserJson request,
            [FromServices] IRegisterUserUseCase useCase)
        {
            try
            {
                var response = await useCase.Execute(request);

                return Created(string.Empty, response);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { messages = ex.GetErrors() });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocorreu um erro inesperado no servidor. Tente novamente mais tarde." });
            }

        }

    }
}
