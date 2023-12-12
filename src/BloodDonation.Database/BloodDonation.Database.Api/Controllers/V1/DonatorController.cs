using BloodDonation.Database.Application.Commands.DonatorEvents.AddDonator;
using BloodDonation.Database.Application.Models.ViewModel;
using BloodDonation.Database.Core.Common.Events;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonation.Database.Api.Controllers.V1
{
    [ApiController]
    [Route("api/v1/donator")]
    public class DonatorController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateDonatorAsync(
            [FromServices] IRequestHandler<AddDonatorCommand, DonatorViewModel> handler,
            [FromBody] AddDonatorCommand command
            )
        {
            return Ok(await handler.Handle(command));
        }
    }
}
