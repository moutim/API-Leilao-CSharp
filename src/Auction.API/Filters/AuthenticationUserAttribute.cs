using Auction.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Auction.API.Filters;

public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        try
        {
            string token = TokenOnRequest(context.HttpContext);

            string email = FromBase64String(token);

            AuctionDbContext repository = new();

            bool exist = repository.Users.Any(user => user.Email.Equals(email));
            if (!exist)
            {
                context.Result = new UnauthorizedObjectResult("Email not valid");
            }

        } 
        catch (Exception ex)
        {
            context.Result = new UnauthorizedObjectResult(ex.Message);
        }
        
    }

    public string TokenOnRequest(HttpContext context)
    {
        string authentication = context.Request.Headers.Authorization.ToString();

        if (string.IsNullOrEmpty(authentication)) throw new Exception("Token is missing!");

        string token = authentication["Bearer ".Length..];

        return token;
    }

    public string FromBase64String(string base64)
    {
        byte[] data = Convert.FromBase64String(base64);

        string converted = System.Text.Encoding.UTF8.GetString(data);

        return converted;
    }
}
