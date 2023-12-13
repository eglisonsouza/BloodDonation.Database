using BloodDonation.Database.Application.Commands.DonationEvents.AddDonation;
using BloodDonation.Database.Application.Models.ViewModel;
using BloodDonation.Database.Core.Common.Events;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonation.Database.Api.Controllers.V1
{
    [ApiController]
    [Route("api/v1/donation")]
    public class DonationController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateDonationAsync(
            [FromServices] IRequestHandler<AddDonationCommand, DonationViewModel> handler,
            [FromBody] AddDonationCommand command
        )
        {
            return Ok(await handler.Handle(command));
        }
    }
}
