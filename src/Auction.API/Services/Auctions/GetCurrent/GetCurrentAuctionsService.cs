namespace Auction.API.Services.Auctions.GetCurrent;

using Auction.API.Entities;

public class GetCurrentAuctionsService
{
    public Auction Execute()
    {
        return new Auction
        {
            Id = 1,
            Ends = DateTime.Now,
            Starts = DateTime.Now,
            Name = "Test"
        };
    }
}
