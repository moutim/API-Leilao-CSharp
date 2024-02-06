namespace Auction.API.Controllers;

using Auction.API.Services.Auctions.GetCurrent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Auction.API.Entities;

[Route("api/[controller]")]
[ApiController]
public class AuctionController : ControllerBase
{
    [HttpGet]
    public IActionResult GetCurrentAuction()
    {
        GetCurrentAuctionsService useService = new();

        Auction result = useService.Execute();

        return Ok(result);
    }
}
