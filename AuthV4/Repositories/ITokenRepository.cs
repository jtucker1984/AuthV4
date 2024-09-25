using Microsoft.AspNetCore.Identity;

namespace AuthV4.Repositories
{
    public interface ITokenRepository
    {
        string CreateJwTToken(IdentityUser user, List<string> roles);
    }
}
