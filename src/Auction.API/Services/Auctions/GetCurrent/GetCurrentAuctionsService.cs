namespace Auction.API.Services.Auctions.GetCurrent;

using Auction.API.Entities;
using Auction.API.Repositories;
using Microsoft.EntityFrameworkCore;

public class GetCurrentAuctionsService
{
    public Auction? Execute()
    {
        AuctionDbContext repository = new();

        DateTime today = new(2024, 01, 25);

        Auction? result = repository.Auctions.Include(auction => auction.Items).FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);

        return result;
    }
}
