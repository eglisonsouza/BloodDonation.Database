using BloodDonation.Database.Application.Models.ViewModel;
using BloodDonation.Database.Application.Query.StockEvents.GetLowStock;
using BloodDonation.Database.Core.Common.Events;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonation.Database.Api.Controllers.V1
{
    [ApiController]
    [Route("api/v1/stock-donation")]
    public class StockDonationController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync(
            [FromServices] IRequestHandler<GetLowStockQuery, List<BloodStockViewModel>> handler,
            [FromQuery] GetLowStockQuery query)
        {
            return Ok(await handler.Handle(query));
        }
    }
}
