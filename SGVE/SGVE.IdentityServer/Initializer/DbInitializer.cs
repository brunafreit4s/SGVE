using IdentityModel;
using Microsoft.AspNetCore.Identity;
using SGVE.IdentityServer.Configuration;
using SGVE.IdentityServer.Models.Sql;
using SGVE.IdentityServer.Models.Sql.Context;
using System.Security.Claims;

namespace SGVE.IdentityServer.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly SqlContext _context;
        private readonly UserManager<ApplicationUser> _user;
        private readonly RoleManager<IdentityRole> _role;

        public DbInitializer(SqlContext context, UserManager<ApplicationUser> user, RoleManager<IdentityRole> role)
        {
            _context = context;
            _user = user;
            _role = role;
        }

        public void Initialise()
        {
            /* Verifica se no banco existe alguém com perfil de Admin */
            if(_role.FindByNameAsync(IdentityConfiguration.Admin).Result != null ) { return; } /* se já fez a carga, sai da verificação */
            _role.CreateAsync(new IdentityRole(IdentityConfiguration.Admin)).GetAwaiter().GetResult(); 
            _role.CreateAsync(new IdentityRole(IdentityConfiguration.Client)).GetAwaiter().GetResult();

            /*Configurações para administrador*/
            ApplicationUser admin = new ApplicationUser()
            {
                UserName = "Bruna-Admin",
                Email = "gerente@geral.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (11) 12345-6789",
                Nome = "Bruna Admin"
            };

            _user.CreateAsync(admin, "Admin123$").GetAwaiter().GetResult();
            _user.AddToRoleAsync(admin, IdentityConfiguration.Admin).GetAwaiter().GetResult();

            var adminClaims = _user.AddClaimsAsync(admin, new Claim[]{
                new Claim(JwtClaimTypes.Name, admin.Nome),
                new Claim(JwtClaimTypes.GivenName, admin.Nome),
                new Claim(JwtClaimTypes.FamilyName, admin.Nome),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Admin)
            }).Result;

            /*Configurações para client*/
            ApplicationUser client = new ApplicationUser()
            {
                UserName = "Bruna-client",
                Email = "gerente@geral.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (11) 12345-6789",
                Nome = "Bruna client"
            };

            _user.CreateAsync(client, "Client123$").GetAwaiter().GetResult();
            _user.AddToRoleAsync(client, IdentityConfiguration.Client).GetAwaiter().GetResult();

            var clienteClaims = _user.AddClaimsAsync(client, new Claim[]{
                new Claim(JwtClaimTypes.Name, client.Nome),
                new Claim(JwtClaimTypes.GivenName, client.Nome),
                new Claim(JwtClaimTypes.FamilyName, client.Nome),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Client)
            }).Result;
        }
    }
}
