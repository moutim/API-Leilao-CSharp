namespace Auction.API.Controllers;

using Auction.API.Services.Auctions.GetCurrent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Auction.API.Entities;

[Route("[controller]")]
[ApiController]
public class AuctionController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(Auction[]), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetCurrentAuction()
    {
        GetCurrentAuctionsService useService = new();

        Auction result = useService.Execute();

        if (result is null) return NoContent();

        return Ok(result);
    }
}
