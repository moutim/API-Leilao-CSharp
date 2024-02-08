using Auction.API.Entities;
using Auction.API.Filters;
using Auction.API.Repositories;

namespace Auction.API.middlewares;

public class LoggedUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LoggedUser(IHttpContextAccessor httpContext)
    {
        _httpContextAccessor = httpContext;
    }

    public User? User()
    {
        AuctionDbContext repository = new();

        AuthenticationUserAttribute authentication = new();

        string token = authentication.TokenOnRequest(_httpContextAccessor.HttpContext!);
        string email = authentication.FromBase64String(token);

        User? user = repository.Users.FirstOrDefault(user => user.Email.Equals(email));

        return user;
    }
}
