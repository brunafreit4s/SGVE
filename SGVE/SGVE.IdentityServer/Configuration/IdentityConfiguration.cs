using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace SGVE.IdentityServer.Configuration
{
    public static class IdentityConfiguration
    {
        public const string Admin = "Admin";
        public const string Client = "Client";

        /* Definições do Identity Resource */

        public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource> {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile(),
        };

        /* Configurações de segurança (relação 1-1) */
        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope> {
            new ApiScope("SGVE", "SGVE - Server"),
            new ApiScope(name: "read", "Read data."),
            new ApiScope(name: "write", "Write data."),
            new ApiScope(name: "delete", "Delete data."),
        };

        public static IEnumerable<Client> Clients => new List<Client>
        {
            new Client
            {
                ClientId = "client",
                ClientSecrets = { new Secret("my_super_scret".Sha256()) },
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = { "read", "write", "profile" }
            },

            new Client
            {
                ClientId = "sgve",
                ClientSecrets = { new Secret("my_super_scret".Sha256()) },
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = { "http://localhost:4430/signin-oidc" },
                PostLogoutRedirectUris = { "http://localhost:4430/signout-callback-oidc" },
                AllowedScopes = new List<string> { 
                    IdentityServerConstants.StandardScopes.OpenId,  
                    IdentityServerConstants.StandardScopes.Email,  
                    IdentityServerConstants.StandardScopes.Profile,  
                }
            }
        };
    }
}
