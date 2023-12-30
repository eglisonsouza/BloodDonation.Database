using BloodDonation.Database.Application.Commands.DonationEvents.AddDonation;
using BloodDonation.Database.Application.Models.ViewModel;
using BloodDonation.Database.Application.Query.DonationEvents.FindDonationsByIdDonator;
using BloodDonation.Database.Application.Query.DonationEvents.GetHistoryDonation;
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

        [HttpGet("all-donations-by-donator")]
        public async Task<IActionResult> GetDonationsByIdDonatorAsync(
            [FromServices] IRequestHandler<FindDonationsByIdDonatorQuery, DonatorWithDonationsViewModel> handler,
            [FromQuery] FindDonationsByIdDonatorQuery query
        )
        {
            return Ok(await handler.Handle(query));
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetHistoryAsync(
            [FromServices] IRequestHandler<GetHistoryDonationQuery, List<HistoryDonationViewModels>> handler,
            [FromQuery] GetHistoryDonationQuery query
        )
        {
            return Ok(await handler.Handle(query));
        }
    }
}
