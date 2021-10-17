using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace eShopPanel.Areas.Panel.Account
{
    [Route("[area]/[action]")]
    public partial class AccountController : BaseController
    {
        private readonly IMediator _mediator;

        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] SignIn.Command command)
        {
            var commandResult = await _mediator.Send(command);
            if (!commandResult.ValidCredentials)
            {
                return Unauthorized("Some of your information is incorrect. Try again.");
            }

            return Ok(commandResult.AccessToken);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] SignUp.Command command)
        {
            var commandResult = await _mediator.Send(command);
            if (commandResult.IdentityResult.Errors.Any())
            {
                foreach (var error in commandResult.IdentityResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return BadRequest(ModelState);
            }

            return Ok();
        }
    }
}
