using Microsoft.AspNetCore.Identity;

namespace SGVE.IdentityServer.Models.Sql
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
