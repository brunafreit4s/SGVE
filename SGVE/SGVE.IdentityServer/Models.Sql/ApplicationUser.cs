using Microsoft.AspNetCore.Identity;

namespace SGVE.IdentityServer.Models.Sql
{
    public class ApplicationUser : IdentityUser
    {
        private string Nome { get; set; }
    }
}
