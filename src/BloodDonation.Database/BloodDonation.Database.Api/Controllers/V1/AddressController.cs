using BloodDonation.Database.Application.Query.ZipCodeEvent.FindByZipCode;
using BloodDonation.Database.Application.Query.ZipCodeEvent.Models;
using BloodDonation.Database.Core.Common.Events;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonation.Database.Api.Controllers.V1
{
    [Route("api/v1/address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        [HttpGet("find-by-zipcode")]
        public async Task<IActionResult> GetAsync(
            [FromServices] IRequestHandler<FindByZipCodeQuery, ZipCodeViewModel> handler,
            [FromQuery] FindByZipCodeQuery query
            )
        {
            return Ok(await handler.Handle(query));
        }
    }
}
