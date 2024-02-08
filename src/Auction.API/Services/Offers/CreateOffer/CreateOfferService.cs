namespace Auction.API.Services.Offers.CreateOffer;

using Auction.API.Communication.Requests;
using Auction.API.Entities;
using Auction.API.middlewares;
using Auction.API.Repositories;

public class CreateOfferService
{
    private readonly LoggedUser _loggedUser;

    public CreateOfferService(LoggedUser loggedUser) => _loggedUser = loggedUser;

    public int Execute(int itemId, RequestCreateOfferJson body)
    {
        AuctionDbContext repository = new();

        User? user = _loggedUser.User();

        Offer offer = new Offer
        {
            CreatedOn = DateTime.Now,
            Price = body.Price,
            ItemId = itemId,
            UserId = user.Id,
        };

        repository.Offers.Add(offer);

        repository.SaveChanges();

        return offer.Id;
    }
}
