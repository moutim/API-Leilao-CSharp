using Auction.API.Communication.Requests;
using Auction.API.Filters;
using Auction.API.Services.Offers.CreateOffer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Auction.API.Controllers;
[ServiceFilter(typeof(AuthenticationUserAttribute))]
public class OfferController : AuctionBaseController
{
    [HttpPost]
    [Route("{itemId}")]
    public IActionResult CreateOffer(
        [FromRoute] int itemId,
        [FromBody] RequestCreateOfferJson body,
        [FromServices] CreateOfferService service
        )
    {
        int id = service.Execute(itemId, body);
        return Created(string.Empty, id);
    }
}
