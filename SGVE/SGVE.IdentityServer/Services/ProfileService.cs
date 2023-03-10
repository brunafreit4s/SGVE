using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using Duende.IdentityServer.Stores;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using SGVE.IdentityServer.Models.Sql;
using System.Security.Claims;

namespace SGVE.IdentityServer.Services
{
    public class ProfileService : IProfileService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;

        public ProfileService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            string id = context.Subject.GetSubjectId();

            /* recupera o usuário */
            ApplicationUser user = await _userManager.FindByIdAsync(id);
            ClaimsPrincipal userClaims = await _userClaimsPrincipalFactory.CreateAsync(user);

            /* Convert as claims em uma lista de claims */
            List<Claim> claims = userClaims.Claims.ToList();

            /* Bruna ---> verificar se será isso mesmo */
            claims.Add(new Claim(JwtClaimTypes.FamilyName, user.Name));
            claims.Add(new Claim(JwtClaimTypes.GivenName, user.Name));

            if (_userManager.SupportsUserRole)
            {
                IList<string> roles = await _userManager.GetRolesAsync(user);
                foreach (string role in roles)
                {
                    claims.Add(new Claim(JwtClaimTypes.Role, role));
                    if (_roleManager.SupportsRoleClaims)
                    {
                        IdentityRole identityRole = await _roleManager.FindByNameAsync(role);
                        if(identityRole != null) { claims.AddRange(await _roleManager.GetClaimsAsync(identityRole)); }
                    }
                }
            }

            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            string id = context.Subject.GetSubjectId();

            /* recupera o usuário */
            ApplicationUser user = await _userManager.FindByIdAsync(id);
            context.IsActive= user != null; 
        }
    }
}
